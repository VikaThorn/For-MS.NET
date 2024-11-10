using LostPropertyOffice.DataAccess;
using LostPropertyOffice.DataAccess.Entities;
using LostPropertyOffice.BL.Users.Provider;
using LostPropertyOffice.BL.Users.Manager;
using LostPropertyOffice.Repository;
using LostPropertyOffice.Service.Settings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LostPropertyOffice.Service.IoC
{
    public static class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services, LostPropertyOfficeSettings settings)
        {
            services.AddDbContext<LostPropertyOfficeDbContext>(options =>
                options.UseNpgsql(settings.LostPropertyOfficeDbContextConnectionString));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();
            services.AddScoped<IUsersProvider, UsersProvider>();
            services.AddScoped<IUsersManager, UsersManager>();
        }
    }
}