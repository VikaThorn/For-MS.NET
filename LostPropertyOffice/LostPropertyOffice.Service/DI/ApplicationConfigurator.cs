using LostPropertyOffice.Service.IoC;
using LostPropertyOffice.Service.Settings;

namespace LostPropertyOffice.Service.DI
{
    public static class ApplicationConfigurator
    {
        public static void ConfigureServices(WebApplicationBuilder builder, LostPropertyOfficeSettings settings)
        {
            AuthorizationConfigurator.ConfigureServices(builder.Services, settings);
            SerilogConfigurator.ConfigureService(builder);
            SwaggerConfigurator.ConfigureServices(builder.Services);
            DbContextConfigurator.ConfigureServices(builder.Services, settings);
            MapperConfigurator.ConfigureServices(builder.Services);
            ServicesConfigurator.ConfigureServices(builder.Services, settings);
            builder.Services.AddControllers();
        }

        public static void ConfigureApplication(WebApplication app)
        {
            AuthorizationConfigurator.ConfigureApplication(app);
            SerilogConfigurator.ConfigureApplication(app);
            SwaggerConfigurator.ConfigureApplication(app);
            DbContextConfigurator.ConfigureApplication(app);
            app.MapControllers();
        }
    }
}