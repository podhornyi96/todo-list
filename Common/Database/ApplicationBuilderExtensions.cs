using Microsoft.EntityFrameworkCore;

namespace TodoListService.Common.Database;

public static class ApplicationBuilderExtensions
{
    public static void SyncMigrations<T>(this IApplicationBuilder app) where T : DbContext
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<T>();
        context.Database.Migrate();
    }
}