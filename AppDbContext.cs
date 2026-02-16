using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ConsoleApp1
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=TestDb;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }
    }
}
