using System;
using System.Collections.Generic;
using System.Linq;
using Aizome.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class PostgresRepository<T> :IRepository<T> where T : DbEntity
    {
        private readonly AizomeContext _context;
        protected DbSet<T> _set { get; set; }

        public PostgresRepository(AizomeContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _set.ToList();

        public T GetById(int id) => _set.FirstOrDefault(x => x.Id == id);

        public void Add(T obj) => _set.Add(obj);

        public void Remove(int id) => _set.Remove(GetById(id));

        public void Update(T obj) => _set.Update(obj);

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}