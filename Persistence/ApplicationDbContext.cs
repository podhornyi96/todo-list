using Microsoft.EntityFrameworkCore;
using TodoListService.Domain;

namespace TodoListService.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TodoListItem> TodoListItems { get; set; }
    
}