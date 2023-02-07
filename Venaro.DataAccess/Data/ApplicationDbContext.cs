using Microsoft.EntityFrameworkCore;
using Venaro.Models;

namespace Venaro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Clothes> Clothes { get; set; } 
    }
}
