using JwtSolution.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JwtSolution.DataAccess.Abstract
{
    public interface IAppRoleDal : IGenericDal<AppRole>
    {
        Task<List<AppRole>> GetRolesByUsername(string username);
    }
}
