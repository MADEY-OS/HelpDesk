using DataAccessLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Data
{
    public class HelpDeskDbContext : DbContext
    {
        private string _connectionString = @"; Database = HelpDesk; Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>().HasOne(r => r.Category)
                .WithMany(c => c.Requests)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(r => r.User)
                .WithMany(u => u.Requests)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Request>().HasOne(r => r.Device)
                .WithMany(d => d.Requests)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Device>().HasOne(d => d.Building)
                .WithMany(b => b.Devices)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(d => d.BuildingId);
            modelBuilder.Entity<Device>().HasOne(d => d.User)
                .WithMany(d => d.Devices)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Entity<User>().HasOne(u => u.Building)
                .WithMany(b => b.Users)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().Property(u => u.RoleId).HasDefaultValue(5);
            modelBuilder.Entity<Request>().Property(r => r.Date).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Request>().Property(r => r.Status).HasDefaultValue("Nowe");

        }
    }
}
