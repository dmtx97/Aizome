using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class JeanPgRepository : PostgresRepository<Jean>, IRepository<Jean>
    {
        private readonly AizomeContext _context;

        public JeanPgRepository(AizomeContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Jean> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(Jean obj)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Jean obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Jean obj)
        {
            throw new NotImplementedException();
        }
    }
}
