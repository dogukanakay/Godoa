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

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            var result = await _authService.CreateAccessToken(userToLogin.Data);
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
         
        }

        [HttpPost("register")]

        public async  Task<IActionResult> Register(UserForRegisterDto userForRegisterDto) 
        {
            var userExists = await _authService.UserExist(userForRegisterDto.Email); //Kullanıcının maili daha önce var mı kontrol ediyor

            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }
            var userToRegister = _authService.Register(userForRegisterDto); //Kayıt işlemini yapıyor
            var result = await _authService.CreateAccessToken(userToRegister.Data); //JWT üretiyor
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       

    }
}
