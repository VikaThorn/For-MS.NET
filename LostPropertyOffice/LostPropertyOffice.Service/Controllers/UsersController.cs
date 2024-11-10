using AutoMapper;
using LostPropertyOffice.BL.Users.Entity;
using LostPropertyOffice.BL.Users.Manager;
using LostPropertyOffice.BL.Users.Provider;
using LostPropertyOffice.Service.Controllers.Entities;
using LostPropertyOffice.DataAccess.Entities; 
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace LostPropertyOffice.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _usersManager;
        private readonly IUsersProvider _usersProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersController(IUsersManager usersManager, IUsersProvider usersProvider,
            IMapper mapper, ILogger logger)
        {
            _usersManager = usersManager;
            _usersProvider = usersProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
        {
            // Регистрация пользователя
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _usersProvider.GetUsers();
            return Ok(new UsersListResponse()
            {
                Users = users.Select(_mapper.Map<UserEntity>).ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredUsers([FromBody] UserFilter filter)
        {
            var userFilterModel = _mapper.Map<UserFilterModel>(filter);
            var users = _usersProvider.GetUsers(userFilterModel);
            return Ok(new UsersListResponse()
            {
                Users = users.Select(_mapper.Map<UserEntity>).ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserInfo(int id)
        {
            var user = _usersProvider.GetUserInfo(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpdateUserInfo([FromBody] UpdateUserModel request)
        {
            // Обновление информации о пользователе
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Удаление пользователя
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            // Вход пользователя
            return Ok();
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            // Выход пользователя
            return Ok();
        }
    }
}
