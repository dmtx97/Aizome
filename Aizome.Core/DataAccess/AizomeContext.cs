using Aizome.Core.DataAccess.Entities;
using Azure.Storage.Blobs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aizome.Core.DataAccess
{
    public class AizomeContext : DbContext
    {
        public AizomeContext(DbContextOptions<AizomeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO : set .HasForeignKey to k.Jean.Id instead
            modelBuilder.Entity<Jean>()
                .HasOne(x => x.User)
                .WithMany(j => j.Jeans)
                .HasForeignKey(k => k.UserForeignKey);

            modelBuilder.Entity<Timeline>()
                .HasOne(t => t.Jean)
                .WithMany(j => j.Timelines)
                .HasForeignKey(k => k.JeanForeignKey);

            modelBuilder.Entity<Blob>()
                .HasOne(b => b.Jean)
                .WithMany(j => j.Blobs)
                .HasForeignKey(k => k.JeanForeignKey);

            //modelBuilder.Entity<Jean>().Property(p => p.JeanId).UseSerialColumn();
            //modelBuilder.Entity<Blob>().Property(p => p.BlobId).UseSerialColumn();
            //modelBuilder.Entity<User>().Property(p => p.UserId).UseSerialColumn();
            //modelBuilder.Entity<Timeline>().Property(p => p.TimelineId).UseSerialColumn();
            modelBuilder.Entity<Jean>().Property(p => p.DateAdded).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Timeline>().Property(p => p.TimelineDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Timeline>().Property(p => p.Action).HasConversion(new EnumToStringConverter<TimelineActions>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Jean> Jeans { get; set; }
        public DbSet<Timeline> Timelines { get; set; }
        public DbSet<Blob> Blobs { get; set; }
    }
}
