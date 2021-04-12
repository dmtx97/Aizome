using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class TimelinePgRepository : PostgresRepository<Timeline>, IRepository<Timeline>
    {
        private readonly AizomeContext _context;

        public TimelinePgRepository(AizomeContext context) : base(context)
        {
        }

        public IEnumerable<Timeline> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Timeline obj)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Timeline obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Timeline obj)
        {
            throw new NotImplementedException();
        }
    }
}