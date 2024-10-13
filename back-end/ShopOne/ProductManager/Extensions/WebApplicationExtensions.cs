using Microsoft.EntityFrameworkCore;

public static class WebApplicationExtensions
{
    public static void MigrateDatabase<T>(this IHost host) where T : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<T>();

            context.Database.Migrate();
        }
    }
}
