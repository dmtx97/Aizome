using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class BlobPgRepository : PostgresRepository<Blob>, IBlobRepository
    {
        public BlobPgRepository(AizomeContext context) : base(context)
        {
        }

        public async Task AddBlobToJean(string fileName, string containerName, int jeanId)
        {
            var jeanItem = _set.FirstOrDefault(x => x.JeanForeignKey == jeanId)?.Jean;

            if (jeanItem == null)
            {
                throw new ArgumentException(nameof(jeanItem));
            }

            await _set.AddAsync(new Blob() {FileId = fileName, ContainerName = containerName, JeanForeignKey = jeanId});
        }

        public Blob GetBlobByFileId(string fileId) => _set.FirstOrDefault(x => x.FileId == fileId);

        public IEnumerable<Blob> GetBlobsByJeanId(int jeanId) => _set.Where(x => x.JeanForeignKey == jeanId);

        public Blob GetBlobByJeanId(string fileName, int jeanId) => GetBlobsByJeanId(jeanId).FirstOrDefault(x => x.FileId == fileName);
    }
}