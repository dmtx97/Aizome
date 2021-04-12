using System.Collections;
using System.Collections.Generic;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories
{
    public interface IBlobRepository : IRepository<Blob>
    {
        public IEnumerable<Blob> GetByJeanId(string jeanId, string userName);
    }
}