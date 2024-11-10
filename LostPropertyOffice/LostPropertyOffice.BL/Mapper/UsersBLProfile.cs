using AutoMapper;
using LostPropertyOffice.BL.Users.Entity;
using LostPropertyOffice.DataAccess.Entities;

namespace LostPropertyOffice.BL.Mapper
{
    public class UsersBLProfile : Profile
    {
        public UsersBLProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => (src as VisitorEntity) != null ? (src as VisitorEntity).EmailAddress : null))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => (src as EmployeeEntity) != null ? (src as EmployeeEntity).Position : null))
                .ReverseMap();

            CreateMap<CreateUserModel, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<UpdateUserModel, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore());
        }
    }
}
