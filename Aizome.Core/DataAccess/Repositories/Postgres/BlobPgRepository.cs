using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.Entities;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class BlobPgRepository : PostgresRepository<Blob>, IBlobRepository
    {
        public BlobPgRepository(AizomeContext context) : base(context)
        {
        }
    }
}