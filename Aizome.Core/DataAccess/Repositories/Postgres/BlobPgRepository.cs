using System;
using System.Collections.Generic;
using System.Linq;
using Aizome.Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aizome.Core.DataAccess.Repositories.Postgres
{
    public class BlobPgRepository : PostgresRepository<Blob>, IBlobRepository
    {
        public BlobPgRepository(AizomeContext context) : base(context)
        {
        }

        public Blob GetBlobByFileId(string fileId) => Set.FirstOrDefault(x => x.FileId == fileId);

        public IEnumerable<Blob> GetBlobsByJeanId(int jeanId) => Set.Where(x => x.JeanForeignKey == jeanId);

        public Blob GetBlobByJeanId(string fileName, int jeanId) =>
            GetBlobsByJeanId(jeanId).FirstOrDefault(x => x.FileId == fileName);

        public bool ValidForeignKey(int id)
        {
            return Set.FirstOrDefault(x => x.JeanForeignKey == id) != null;
        }
    }


    public static class RepositoryHelpers
    {
        // TODO : maybe set foreignkey as a dbset property?
        //public static bool ValidForeignKey<T>(this DbSet<T> Set, int id) where T : DbEntity
        //{
        //    return Set.FirstOrDefault(x => x.ForeignKey == id) != null
        //}
    }

}