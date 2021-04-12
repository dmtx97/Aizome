using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class BlobPgRepository : IBlobRepository
    {
        public Blob GetByFileId(string fileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blob> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Blob blob)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Blob blob)
        {
            throw new NotImplementedException();
        }

        public Task Update(Blob blob)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blob> GetByJeanId(string jeanId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}