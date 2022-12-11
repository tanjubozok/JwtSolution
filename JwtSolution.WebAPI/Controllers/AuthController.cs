using JwtSolution.Business.Abstract;
using JwtSolution.Dtos.AppUserDtos;
using JwtSolution.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JwtSolution.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;

        public AuthController(IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> Signin(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUsername(appUserLoginDto.Username);
            if (appUser != null)
            {
                if (await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var token = _jwtService.GenerateJwt(appUser, null);
                    return Created("", token);
                }
            }
            return BadRequest("Kullanıcı adı veya şifre hatalıdır");
        }
    }
}
