using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class UserPgRepository : PostgresRepository<User>, IUserRepository
    {
        public UserPgRepository(AizomeContext context) : base(context)
        {
        }
    }
}