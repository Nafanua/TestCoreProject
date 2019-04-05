using Microsoft.EntityFrameworkCore;
using TestApp.DataAccess.Models;

namespace TestApp.DataAccess
{
    public sealed class AppContext : DbContext
    {
        private string ConnectionString { get; }

        public AppContext(string connectionString) : base()
        {
            ConnectionString = connectionString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<SiteDbo> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteDbo>().ToTable("Sites");
            modelBuilder.Entity<SiteDbo>().HasKey(i => i.Id);
            modelBuilder.Entity<SiteDbo>().Property(i => i.TaskId).IsRequired();
            modelBuilder.Entity<SiteDbo>().Property(i => i.LocationId).IsRequired();
            modelBuilder.Entity<SiteDbo>().Property(i => i.KeyId).IsRequired();
            modelBuilder.Entity<SiteDbo>().Property(i => i.PostId).IsRequired();
            modelBuilder.Entity<SiteDbo>().Property(i => i.SearchEngineId).IsRequired();
            modelBuilder.Entity<SiteDbo>().Property(i => i.PostKey).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<SiteDbo>().Property(i => i.PostSite).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<SiteDbo>().Property(i => i.Status).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<SiteDbo>().Property(i => i.LocationId).IsRequired();
        }
    }
}
