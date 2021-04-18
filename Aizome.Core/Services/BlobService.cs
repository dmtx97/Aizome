﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Repositories;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Aizome.Core.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IBlobRepository _blobRepository;
        public BlobService(IBlobRepository blobRepository, BlobServiceClient blobServiceClient)
        {
            _blobRepository = blobRepository;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<Response> CreateBlobContainer(string containerName) => (await _blobServiceClient.CreateBlobContainerAsync(containerName)).GetRawResponse();

        public async Task<Response> DeleteBlobContainer(string containerName) => (await _blobServiceClient.DeleteBlobContainerAsync(containerName));
        
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
         
            var bytes = Convert.FromBase64String(base64String);
            
            var stream = new MemoryStream(bytes);

            var clients = await GetBlobClients(containerName, fileName);

            try
            {
                if (clients.blobClient != null && clients.blobClient.UploadAsync(stream, new BlobHttpHeaders() {ContentType = "image/jpg"}).Result
                    .GetRawResponse().Status == 200)
                {
                    await _blobRepository.AddBlobToJean(fileName, containerName, jeanId);

                    return true;
                }
            }
            catch (RequestFailedException e)
            {
                Debug.WriteLine("HTTP error code {0}: {1}", e.Status, e.ErrorCode);
            }
           
            return false;
        }

        public async Task<bool> DeleteBlob(string fileName)
        {
            var blob = _blobRepository.GetBlobByFileId(fileName);

            if (blob != null)
            {
                var clients = await GetBlobClients(blob.ContainerName, fileName);

                try
                {
                    if ((await clients.blobClient.DeleteAsync()).Status == 200)
                    {
                        _blobRepository.Remove(blob.Id);

                        return true;
                    }
                }
                catch (RequestFailedException e)
                {
                    Debug.WriteLine("Unexpected error trying to delete {0} : {1}", fileName, e);
                }
            }

            return false;
        }

        // TODO : Will there be any instances where I do need to use the BlobContainerClient?
        public async Task<(BlobContainerClient blobContainerClient, BlobClient blobClient)> GetBlobClients(
            string containerName, string fileName)
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

        public async Task<bool> Execute(Func<string, Task<Response>> containerAction, string containerName)
        {
            try
            {
                return (await containerAction(containerName)).Status == 200;
            }

            catch (RequestFailedException e)
            {
                Debug.WriteLine("HTTP error code {0}: {1}", e.Status, e.ErrorCode);
            }

            return false;
        }
    }

    public interface IBlobService
    {
        public Task<Response> CreateBlobContainer(string containerName);

        public Task<Response> DeleteBlobContainer(string containerName);

        public Task<BlobContentDTO> GetBlob(string fileName);

        public Task<bool> UploadBlob(string base64String, string containerName, int jeanId);

        public Task<bool> DeleteBlob(string fileName);

        public Task<bool> Execute(Func<string, Task<Response>> containerAction, string containerName);
    }
}
