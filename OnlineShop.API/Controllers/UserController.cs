using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Services;
using OnlineShop.API.Shared.ViewModels;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            return Ok(_userService.GetCounties());
        }

        [HttpGet("states")]
        public IActionResult GetStates([FromQuery] int countryId)
        {
            return Ok(_userService.GetStates(countryId));
        }

        [HttpPost("Register")]
        public IActionResult Register(UserDetails register)
        {
            try
            {
                var result = _userService.Register(register);
                if (result)
                {
                    return Ok(result) ;
                }
                else
                {
                    return BadRequest("Invalid registration");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var result =await _userService.Login(login);
            if (!string.IsNullOrEmpty(result.Token))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Invalid login");
            }
        }
    }
}
