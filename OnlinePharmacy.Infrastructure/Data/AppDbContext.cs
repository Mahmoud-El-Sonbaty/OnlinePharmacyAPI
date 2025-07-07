using Microsoft.EntityFrameworkCore;
using OnlinePharmacy.Domain.Entities;

namespace OnlinePharmacy.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UsersRoles { get; set; }
    }
}
