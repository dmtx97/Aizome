﻿using System.Collections.Generic;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories
{
    public interface IRepository<T> where T : DbEntity
    {
        IEnumerable<T> GetAll();
        void Add(T obj);
        T GetById(int id);
        T GetLatest();
        void Remove(int id);
        void Update(T obj);
        bool SaveChanges();
    }
}
