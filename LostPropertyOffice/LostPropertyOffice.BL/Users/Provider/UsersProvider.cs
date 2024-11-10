using AutoMapper;
using LostPropertyOffice.BL.Users.Entity;
using LostPropertyOffice.BL.Users.Exceptions;
using LostPropertyOffice.DataAccess.Entities;
using LostPropertyOffice.Repository;

namespace LostPropertyOffice.BL.Users.Provider
{
    public class UsersProvider : IUsersProvider
    {
        private readonly IRepository<UserEntity> _usersRepository;
        private readonly IMapper _mapper;

        public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserModel> GetUsers(UserFilterModel filter)
        {
            var query = _usersRepository.GetAll();

            if (!string.IsNullOrEmpty(filter.Role))
            {
                query = query.Where(u => u.Role.Contains(filter.Role));
            }

            if (!string.IsNullOrEmpty(filter.LoginPart))
            {
                query = query.Where(u => u.Login.Contains(filter.LoginPart));
            }

            if (!string.IsNullOrEmpty(filter.PhoneNumberPart))
            {
                query = query.Where(u => u.PhoneNumber.Contains(filter.PhoneNumberPart));
            }

            if (!string.IsNullOrEmpty(filter.EmailPart))
            {
                query = query.OfType<VisitorEntity>()
                             .Where(u => u.EmailAddress.Contains(filter.EmailPart));
            }

            if (!string.IsNullOrEmpty(filter.Position))
            {
                query = query.OfType<EmployeeEntity>()
                             .Where(u => u.Position.Contains(filter.Position));
            }

            return query.Select(u => _mapper.Map<UserModel>(u)).ToList();
        }

        public UserModel GetUserInfo(int id)
        {
            var entity = _usersRepository.GetById(id);
            if (entity == null)
            {
                throw new UserNotFoundException($"User with ID {id} not found.");
            }
            return _mapper.Map<UserModel>(entity);
        }
    }
}
