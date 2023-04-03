using Microsoft.EntityFrameworkCore;
using TodoListService.Domain;
using TodoListService.Persistence;

namespace TodoListService.Common.Database;

public static class ApplicationBuilderExtensions
{
    public static void SyncMigrations<T>(this IApplicationBuilder app) where T : DbContext
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<T>();
        context.Database.Migrate();
    }

    public static void SeedData(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        
        if (context.TodoLists.Any())
            return;

        var todoList = new TodoList
        {
            TodoListItems = new List<TodoListItem>
            {
                new TodoListItem { Description = "Task 1", IsCompleted = true },
                new TodoListItem { Description = "Task 2", IsCompleted = false },
                new TodoListItem { Description = "Task 3", IsCompleted = false },
                new TodoListItem { Description = "Task 4", IsCompleted = false }
            }
        };

        context.TodoLists.Add(todoList);

        context.SaveChanges();
    }
    
}