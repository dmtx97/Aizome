using System.Collections.Generic;
using System.Linq;
using Aizome.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class PostgresRepository<T> : IRepository<T> where T : DbEntity
    {
        private readonly AizomeContext _context;
        protected DbSet<T> Set { get; set; }

        public PostgresRepository(AizomeContext context)
        {
            _context = context;
            Set = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => Set.ToList();

        public T GetById(int id) => Set.FirstOrDefault(x => x.Id == id);

        public void Add(T obj) => Set.Add(obj);

        public void Remove(int id) => Set.Remove(GetById(id));

        public void Update(T obj) => Set.Update(obj);

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}