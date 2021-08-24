using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;
using Aizome.Core.DataAccess.Repositories;
using AutoMapper;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Aizome.Core.Services
{
    public class BlobService : AizomeService<Blob>, IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IBlobRepository _blobRepository;
        public BlobService(IBlobRepository blobRepository, BlobServiceClient blobServiceClient, IMapper mapper, IRepository<Blob> baseRepository) : base(mapper, baseRepository)
        {
            _blobRepository = blobRepository;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<bool> CreateBlobContainer(string containerName) =>
            await ValidateResponse(() => _blobServiceClient.CreateBlobContainerAsync(containerName));
        
        public async Task<bool> DeleteBlobContainer(string containerName) =>
            await ValidateResponse(() => _blobServiceClient.DeleteBlobContainerAsync(containerName));

        public async Task<BlobContentDTO> GetBlob(string fileName)
        {
            var blob = _blobRepository.GetBlobByFileId(fileName);

            if (blob == null) return null;

            try
            {
                var clients = await GetBlobClients(blob.ContainerName, fileName);

                var blobDownloadInfo = await clients.blobClient.DownloadAsync();

                return new BlobContentDTO(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }

        public async Task<bool> UploadBlob(string base64String, string containerName, int jeanId)
        {
            var fileName = Path.GetRandomFileName().Replace(".", "");
            
            var clients = await GetBlobClients(containerName, fileName);
         
            var bytes = Convert.FromBase64String(base64String);
            
            var stream = new MemoryStream(bytes);

            var uploadBlob = ValidateResponse(() =>
                clients.blobClient.UploadAsync(stream, new BlobHttpHeaders() { ContentType = "image/jpg" }));

            var addBlob = Execute(_blobRepository.Add, null, new Blob()
            {
                FileId = fileName,
                ContainerName = containerName,
                JeanForeignKey = jeanId
            }, false);

            // TODO: include exceptions in return if thrown
            try
            {
                if (clients.blobClient != null && _blobRepository.ValidForeignKey(jeanId))
                {
                    await Task.WhenAll(uploadBlob, addBlob);

                    return uploadBlob.Result && addBlob.Result != null;
                }
            }
            catch (RequestFailedException e)
            {
                Debug.WriteLine("HTTP error code {0}: {1}", e.Status, e.ErrorCode);
                return false;
            }

            return false;
        }

        public async Task<bool> DeleteBlob(string fileName)
        {
            var blob = _blobRepository.GetBlobByFileId(fileName);

            if (blob == null) return false;
            
            var clients = await GetBlobClients(blob.ContainerName, fileName);

            if (await ValidateResponse(() => clients.blobClient.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots)))
            {
                return await Remove(blob.Id);
            }

            return false;
        }

        public async Task<(BlobContainerClient blobContainerClient, BlobClient blobClient)> GetBlobClients(string containerName, string fileName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                if (await containerClient.ExistsAsync())
                {
                    var blobClient = containerClient.GetBlobClient(fileName);

                    if (await blobClient.ExistsAsync())
                    {
                        return (containerClient, blobClient);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not retrieve clients {0}", e);
            }

            return (null, null);
        }

        private static async Task<bool> ValidateResponse<T>(Func<Task<Response<T>>> containerFunc)
        {
            try
            {
                return (await containerFunc()).GetRawResponse().Status == 200;
            }

            catch (RequestFailedException e)
            {
                Debug.WriteLine("HTTP error code {0}: {1}", e.Status, e.ErrorCode);
            }

            return false;
        }

        private static async Task<bool> ValidateResponse(Func<Task<Response>> containerFunc)
        {
            try
            {
                return (await containerFunc()).Status == 200;
            }

            catch (RequestFailedException e)
            {
                Debug.WriteLine("HTTP error code {0}: {1}", e.Status, e.ErrorCode);
            }

            return false;
        }
    }
}
