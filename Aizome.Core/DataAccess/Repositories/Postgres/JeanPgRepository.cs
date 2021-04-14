using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class JeanPgRepository : PostgresRepository<Jean>, IJeanRepository
    {
        public JeanPgRepository(AizomeContext context) : base(context)
        {
        }
    }
}
