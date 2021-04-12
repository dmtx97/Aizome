using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class BlobPgRepository : PostgresRepository<Blob>, IRepository<Blob>
    {
        private readonly AizomeContext _context;

        public BlobPgRepository(AizomeContext context) : base(context)
        {
        }

        public IEnumerable<Blob> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Blob obj)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Blob obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Blob obj)
        {
            throw new NotImplementedException();
        }
    }
}