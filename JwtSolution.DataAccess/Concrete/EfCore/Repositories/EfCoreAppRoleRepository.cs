using JwtSolution.DataAccess.Abstract;
using JwtSolution.DataAccess.Concrete.EfCore.Context;
using JwtSolution.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtSolution.DataAccess.Concrete.EfCore.Repositories
{
    public class EfCoreAppRoleRepository : EfCoreGenericRepository<AppRole>, IAppRoleDal
    {
        public Task<List<AppRole>> GetRolesByUsername(string username)
        {
            DatabaseContext context = new();
            var roles = (from u in context.AppUsers
                         join ur in context.AppUserRoles on u.Id equals ur.AppUserId
                         join r in context.AppRoles on ur.AppRoleId equals r.Id
                         where r.Name == username
                         select new AppRole
                         {
                             Id = r.Id,
                             Name = r.Name
                         });

            return roles.ToListAsync();
        }
    }
}
