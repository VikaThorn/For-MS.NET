using LostPropertyOffice.BL.Users.Entity;
using LostPropertyOffice.DataAccess.Entities;

namespace LostPropertyOffice.Service.Controllers.Entities
{
    public class UsersListResponse
    {
        public List<UserEntity> Users { get; set; }
    }
}