using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class UserPgRepository : PostgresRepository<User>, IUserRepository
    {
        private readonly AizomeContext _context;

        public UserPgRepository(AizomeContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(User obj)
        {
            throw new NotImplementedException();
        }

        public Task Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(User obj)
        {
            throw new NotImplementedException();
        }

        public override void RemoveRange(IEnumerable<User> objects)
        {
            // do nothing
        }
    }
}