using JwtSolution.Entities.Concrete;
using System.Collections.Generic;

namespace JwtSolution.Business.Abstract
{
    public interface IJwtService
    {
        string GenerateJwt(AppUser appUser, List<AppRole> roles);
    }
}
