using JwtSolution.Business.Abstract;
using JwtSolution.DataAccess.Abstract;
using JwtSolution.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JwtSolution.Business.Concrete
{
    public class AppRoleManager : GenericManager<AppRole>, IAppRoleService
    {
        private readonly IAppRoleDal _appRoleDal;

        public AppRoleManager(IGenericDal<AppRole> genericDal, IAppRoleDal appRoleDal) : base(genericDal)
        {
            _appRoleDal = appRoleDal;
        }

        public Task<List<AppRole>> GetRolesByUsername(string username)
        {
            return _appRoleDal.GetRolesByUsername(username);
        }
    }
}
