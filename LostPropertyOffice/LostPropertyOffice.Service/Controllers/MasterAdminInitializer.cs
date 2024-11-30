using Microsoft.AspNetCore.Identity;
using LostPropertyOffice.BL.Auth; 
using LostPropertyOffice.DataAccess.Entities; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.AspNetCore.Builder;

namespace LostPropertyOffice.Service.Controllers
{
    public class MasterAdminInitializer
    {
        public const string MASTER_ADMIN_POSITION = "Admin";
        public const string MASTER_ADMIN_PASSWORD = "AdminPassword123!?";

        private static async Task CreateGlobalAdmin(IAuthProvider authProvider)
        {
            await authProvider.RegisterEmployee(MASTER_ADMIN_PASSWORD, MASTER_ADMIN_POSITION);
        }

        public static async Task InitializeRepository(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = (UserManager<UserEntity>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<UserEntity>));
                var user = await userManager.FindByNameAsync(MASTER_ADMIN_POSITION);
                if (user == null)
                {
                    var authProvider = (IAuthProvider)scope.ServiceProvider.GetRequiredService(typeof(IAuthProvider));
                    await CreateGlobalAdmin(authProvider);
                }
            }
        }
    }
}