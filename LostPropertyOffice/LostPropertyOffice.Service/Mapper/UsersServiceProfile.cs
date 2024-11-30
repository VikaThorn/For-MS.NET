using AutoMapper;
using LostPropertyOffice.BL.Users.Entity;
using LostPropertyOffice.Service.Controllers.Entities;

namespace LostPropertyOffice.Service.Mapper
{
    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile()
        {
            CreateMap<UserFilter, UserFilterModel>();
            CreateMap<RegisterUserRequest, CreateUserModel>();
        }
    }
}