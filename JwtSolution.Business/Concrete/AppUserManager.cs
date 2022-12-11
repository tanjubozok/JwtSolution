using JwtSolution.Business.Abstract;
using JwtSolution.DataAccess.Abstract;
using JwtSolution.Dtos.AppUserDtos;
using JwtSolution.Entities.Concrete;
using System.Threading.Tasks;

namespace JwtSolution.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto)
        {
            var username = await _appUserDal.GetByFilterAsync(x => x.Username == appUserLoginDto.Username);
            return  username.Password == appUserLoginDto.Password;
        }

        public async Task<AppUser> FindByUsername(string username)
        {
            return await _appUserDal.GetByFilterAsync(x => x.Username == username);
        }
    }
}
