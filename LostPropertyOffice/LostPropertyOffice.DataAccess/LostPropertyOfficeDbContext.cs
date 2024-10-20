using LostPropertyOffice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LostPropertyOffice.DataAccess
{
    public class LostPropertyOfficeDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VisitorEntity> Visitors { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<LostItemEntity> LostItems { get; set; }
        public DbSet<ItemTypeEntity> ItemTypes { get; set; }
        public DbSet<NextPointEntity> NextPoints { get; set; }

        public LostPropertyOfficeDbContext(DbContextOptions<LostPropertyOfficeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<VisitorEntity>().HasBaseType<UserEntity>();
            modelBuilder.Entity<EmployeeEntity>().HasBaseType<UserEntity>();

            modelBuilder.Entity<LostItemEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<LostItemEntity>().HasOne(x => x.ItemType)
                .WithMany(x => x.LostItems)
                .HasForeignKey(x => x.ItemTypeId);
            modelBuilder.Entity<LostItemEntity>().HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ItemTypeEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemTypeEntity>().HasOne(x => x.NextPoint)
                .WithMany()
                .HasForeignKey(x => x.NextPointId);

            modelBuilder.Entity<NextPointEntity>().HasKey(x => x.Id);
        }
    }
}