using LostPropertyOffice.DataAccess;
using LostPropertyOffice.Service.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 

namespace LostPropertyOffice.Service.IoC
{
    public static class DbContextConfigurator
    {
        public static void ConfigureServices(IServiceCollection services, LostPropertyOfficeSettings settings)
        {
            services.AddDbContextFactory<LostPropertyOfficeDbContext>(
                options => { options.UseNpgsql(settings.LostPropertyOfficeDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<LostPropertyOfficeDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}