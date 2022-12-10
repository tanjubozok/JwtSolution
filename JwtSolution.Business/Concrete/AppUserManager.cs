using JwtSolution.Business.Abstract;
using JwtSolution.DataAccess.Abstract;
using JwtSolution.Entities.Concrete;

namespace JwtSolution.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
        }
    }
}
