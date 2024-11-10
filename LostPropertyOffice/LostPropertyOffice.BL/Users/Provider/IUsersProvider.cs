using LostPropertyOffice.BL.Users.Entity;

namespace LostPropertyOffice.BL.Users.Provider
{
    public interface IUsersProvider
    {
        IEnumerable<UserModel> GetUsers(UserFilterModel filter = null);
        UserModel GetUserInfo(int id);
    }
}