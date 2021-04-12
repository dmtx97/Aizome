using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class TimelinePgRepository : ITimelineRepository
    {
        public Timeline GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Timeline> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Timeline timeline)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Timeline timeline)
        {
            throw new NotImplementedException();
        }

        public Task Update(Timeline timeline)
        {
            throw new NotImplementedException();
        }
    }
}