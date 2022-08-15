using Microsoft.EntityFrameworkCore;
using RazonPagesLessons.Models;


namespace RazonPagesLessons.Servises
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
