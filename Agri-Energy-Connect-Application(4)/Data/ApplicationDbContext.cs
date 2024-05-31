using Agri_Energy_Connect_Application_4_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect_Application_4_.Data
{/// <summary>
/// DBContext Class
/// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<AddFarmer> AddFarmer { get; set; } 
        public DbSet<AddProduct> AddProduct { get; set; } 

        public DbSet<ApplicationUser> ApplicationUser { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships
            modelBuilder.Entity<AddProduct>()
                .HasOne(p => p.Farmer)
                .WithMany(f => f.Products)
                .HasForeignKey(p => p.FarmerId);
        }
    }
}
