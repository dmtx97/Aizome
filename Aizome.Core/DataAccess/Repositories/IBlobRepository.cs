using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories
{
    public interface IBlobRepository : IRepository<Blob>
    {
        public Blob GetBlobByJeanId(string fileName, int jeanId);

        public Blob GetBlobByFileId(string fileId);

        Task AddBlobToJean(string fileName, string containerName, int jeanId);
    }
}