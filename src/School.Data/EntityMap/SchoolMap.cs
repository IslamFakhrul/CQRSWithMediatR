using Microsoft.EntityFrameworkCore;

namespace School.Data.EntityMap
{
    public static class SchoolMap
    {
        public static ModelBuilder AddSchool(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.School>(entity =>
            {
                entity.ToTable("Schools");
                entity.HasKey(t => t.RefId);
                entity.Property(t => t.SchoolName).IsRequired();
                entity.Property(t => t.SchoolCode).IsRequired();
                entity.Property(t => t.SchoolUrl);
                entity.Property(t => t.SchoolAddress).IsRequired();
                entity.Property(t => t.SchoolType).IsRequired();
                entity.Property(t => t.SchoolSector).IsRequired();
                entity.Property(t => t.SchoolPhoneNumber);
            });

            return modelBuilder;
        }
    }
}
