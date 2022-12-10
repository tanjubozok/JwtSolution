using JwtSolution.DataAccess.Abstract;
using JwtSolution.Entities.Concrete;

namespace JwtSolution.DataAccess.Concrete.EfCore.Repositories
{
    public class EfCoreAppUserRoleRepository : EfCoreGenericRepository<AppUserRole>, IAppUserRoleDal
    {
    }
}
