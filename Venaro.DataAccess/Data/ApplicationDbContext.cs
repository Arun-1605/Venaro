using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Venaro.Models;

namespace Venaro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Clothes> Clothes { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Company> Company { get; set; }    

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Product> Products { get; set; }

		public DbSet<Colors> Colors { get; set; }

		public DbSet<Size> Size { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

		public DbSet<OrderDetail> OrderDetail { get; set; }


	}
}
