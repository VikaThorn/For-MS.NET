using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LostPropertyOffice.BL.Auth;
using LostPropertyOffice.BL.Users.Entity;

namespace LostPropertyOffice.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthProvider _authProvider;

        public AuthController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel model)
        {
            var user = await _authProvider.RegisterUser(model.Email, model.Password);
            return Ok(user);
        }

        [HttpPost("register-employee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterEmployeeModel model)
        {
            var user = await _authProvider.RegisterEmployee(model.Password, model.Position);
            return Ok(user);
        }
    }

    public class RegisterUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterEmployeeModel
    {
        public string Password { get; set; }
        public string Position { get; set; }
    }
}