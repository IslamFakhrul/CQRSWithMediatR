using Microsoft.EntityFrameworkCore;
using School.Data.EntityMap;

namespace School.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddSchool();

            base.OnModelCreating(modelBuilder);

        }
    }
}
