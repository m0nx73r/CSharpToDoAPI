using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;

namespace ToDoAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ToDoItem> TodoItems { get; set; }
    }
}
