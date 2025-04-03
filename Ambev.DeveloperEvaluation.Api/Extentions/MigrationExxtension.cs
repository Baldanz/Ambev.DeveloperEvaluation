using Ambev.DeveloperEvaluation.ORM.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Api.Extentions;

public static class MigrationExxtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using DefaultContext dbContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();

        dbContext.Database.Migrate();
    }
}
