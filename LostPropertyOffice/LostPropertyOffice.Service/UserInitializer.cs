using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using LostPropertyOffice.DataAccess.Entities;

namespace LostPropertyOffice.Service
{
    public static class UserInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();

            var user = new UserEntity { Login = "admin", PasswordHash = "Admin@12345", PhoneNumber = "1234567890" };
            await userManager.CreateAsync(user, "Admin@12345");

            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}