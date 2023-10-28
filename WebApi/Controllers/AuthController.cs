using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]

        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
         
        }

        [HttpPost("register")]

        public IActionResult Register(UserForRegisterDto userForRegisterDto) 
        {
            var userExists = _authService.UserExist(userForRegisterDto.Email);

            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }
            var userToRegister = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(userToRegister.Data);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
