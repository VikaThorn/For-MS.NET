using LostPropertyOffice.BL.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace LostPropertyOffice.Service.IoC
{
    public static class MapperConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<UsersBLProfile>();
            });
        }
    }
}