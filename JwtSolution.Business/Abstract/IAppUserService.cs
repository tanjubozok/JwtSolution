using JwtSolution.Dtos.AppUserDtos;
using JwtSolution.Entities.Concrete;
using System.Threading.Tasks;

namespace JwtSolution.Business.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUsername(string username);
        Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto);
    }
}
