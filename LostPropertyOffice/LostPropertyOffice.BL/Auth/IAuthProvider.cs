using System.Threading.Tasks;
using LostPropertyOffice.BL.Auth.Entities; 
using LostPropertyOffice.BL.Users.Entity;

namespace LostPropertyOffice.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeUser(string email, string password);
        Task<UserModel> RegisterUser(string email, string password);
        Task<UserModel> RegisterEmployee(string password, string position); 
    }
}