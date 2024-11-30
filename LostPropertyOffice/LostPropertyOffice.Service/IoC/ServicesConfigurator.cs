using AutoMapper;
using LostPropertyOffice.BL.Auth;
using LostPropertyOffice.DataAccess;
using LostPropertyOffice.DataAccess.Entities;
using LostPropertyOffice.Repository; // Убедимся, что это пространство имен используется
using LostPropertyOffice.Service.Settings;
using Microsoft.AspNetCore.Identity;

namespace LostPropertyOffice.Service.IoC
{
    public static class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services, LostPropertyOfficeSettings settings)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthProvider>(x =>
                new AuthProvider(
                    x.GetRequiredService<SignInManager<UserEntity>>(),
                    x.GetRequiredService<UserManager<UserEntity>>(),
                    x.GetRequiredService<IHttpClientFactory>(),
                    settings.IdentityServerUri,
                    settings.ClientId,
                    settings.ClientSecret,
                    x.GetRequiredService<IMapper>())); 
        }
    }
}