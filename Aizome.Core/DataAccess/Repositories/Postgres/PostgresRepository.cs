using System.Collections.Generic;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public abstract class PostgresRepository<T> where T : DbEntity
    {

        private readonly AizomeContext _context;

        protected PostgresRepository(AizomeContext context)
        {
            _context = context;
        }

        public virtual void RemoveRange(IEnumerable<T> objects)
        {
            _context.RemoveRange(objects);
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;

    }
}