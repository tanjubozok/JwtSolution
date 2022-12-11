using JwtSolution.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JwtSolution.Business.Abstract
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<List<AppRole>> GetRolesByUsername(string username);
        Task<AppRole> FindByName(string role);
    }
}
