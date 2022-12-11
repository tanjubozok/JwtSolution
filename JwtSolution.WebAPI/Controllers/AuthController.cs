using AutoMapper;
using JwtSolution.Business.Abstract;
using JwtSolution.Dtos.AppUserDtos;
using JwtSolution.Entities.Concrete;
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
        private readonly IAppRoleService _appRoleService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IAppUserService appUserService, IAppRoleService appRoleService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _appRoleService = appRoleService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUsername(appUserLoginDto.Username);
            if (appUser != null)
            {
                if (await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var roles = await _appRoleService.GetRolesByUsername(appUserLoginDto.Username);
                    var token = _jwtService.GenerateJwt(appUser, roles);

                    return Created("", token);
                }
            }
            return BadRequest("Kullanıcı adı veya şifre hatalıdır");
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto)
        {
            var appUser = await _appUserService.FindByUsername(appUserAddDto.Username);
            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.Username} daha önce alınmış");
            }
            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));

            return Created("", appUserAddDto);
        }
    }
}
