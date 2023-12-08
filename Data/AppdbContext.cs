using MicroserviceProject.Models;
using Microsoft.EntityFrameworkCore;
namespace MicroserviceProject.Data
{
    

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }

}
