using AutoMapper;
using JwtSolution.Business.Abstract;
using JwtSolution.Business.StringInfos;
using JwtSolution.Dtos.AppUserDtos;
using JwtSolution.Dtos.Token;
using JwtSolution.Entities.Concrete;
using JwtSolution.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        private readonly IAppUserRoleService _appUserRoleService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IAppUserService appUserService, IAppRoleService appRoleService, IMapper mapper, IAppUserRoleService appUserRoleService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _appRoleService = appRoleService;
            _mapper = mapper;
            _appUserRoleService = appUserRoleService;
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

                    JwtAccessToken jwtAccessToken = new()
                    {
                        Token = token
                    };

                    return Created("", jwtAccessToken);
                }
            }
            return BadRequest("Kullanıcı adı veya şifre hatalıdır");
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto,
            [FromServices] IAppUserRoleService appUserRoleService,
            [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByUsername(appUserAddDto.Username);
            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.Username} daha önce alınmış");
            }
            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByUsername(appUserAddDto.Username);
            var role = await _appRoleService.FindByName(RoleInfo.Member);
            await _appUserRoleService.AddAsync(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            return Created("", appUserAddDto);
        }


        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUsername(User.Identity.Name);
            var roles = await _appRoleService.GetRolesByUsername(User.Identity.Name);
            AppUserDto appUserDto = new AppUserDto
            {
                Fullname = user.Fullname,
                Username = user.Username,
                Roles = roles.Select(x => x.Name).ToList()
            };
            return Ok(appUserDto);
        }
    }
}
