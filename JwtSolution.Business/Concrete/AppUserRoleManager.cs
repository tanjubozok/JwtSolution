using JwtSolution.Business.Abstract;
using JwtSolution.DataAccess.Abstract;
using JwtSolution.Entities.Concrete;

namespace JwtSolution.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal) : base(genericDal)
        {
        }
    }
}
