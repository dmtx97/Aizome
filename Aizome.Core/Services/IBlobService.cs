using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;

namespace Aizome.Core.Services
{
    public interface IBlobService
    {
        public Task<bool> CreateBlobContainer(string containerName);

        public Task<bool> DeleteBlobContainer(string containerName);

        public Task<BlobContentDTO> GetBlob(string fileName);

        public Task<bool> UploadBlob(string base64String, string containerName, int jeanId);

        public Task<bool> DeleteBlob(string fileName);
    }
}