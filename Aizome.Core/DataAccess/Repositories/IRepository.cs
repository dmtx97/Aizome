﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories
{
    public interface IRepository<T> where T : DbEntity
    {
        IEnumerable<T> GetAll();
        Task Add(T obj);
        Task Remove(T obj);
        Task Update(T obj);
    }
}
