using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories
{
    public interface IBlobRepository : IRepository<Blob>
    {
        public Blob GetBlobByJeanId(string fileName, int jeanId);

        public Blob GetBlobByFileId(string fileId);
        public bool ValidForeignKey(int id);
    }
}