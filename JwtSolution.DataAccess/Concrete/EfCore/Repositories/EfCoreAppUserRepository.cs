using JwtSolution.DataAccess.Abstract;
using JwtSolution.Entities.Concrete;

namespace JwtSolution.DataAccess.Concrete.EfCore.Repositories
{
    public class EfCoreAppUserRepository : EfCoreGenericRepository<AppUser>, IAppUserDal
    {
    }
}
