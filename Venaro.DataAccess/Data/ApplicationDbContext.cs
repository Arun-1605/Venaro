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
    }
}
