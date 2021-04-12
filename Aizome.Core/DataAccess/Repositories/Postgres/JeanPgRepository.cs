using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class JeanPgRepository : IJeanRepository
    {
        public Jean GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jean> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Jean jean)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Jean jean)
        {
            throw new NotImplementedException();
        }

        public Task Update(Jean jean)
        {
            throw new NotImplementedException();
        }
    }
}
