using Microsoft.EntityFrameworkCore;
using ToDoAPI.DAL.Entities;

namespace ToDoAPI.DAL.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ToDoEntity> TodoItems { get; set; }
}
