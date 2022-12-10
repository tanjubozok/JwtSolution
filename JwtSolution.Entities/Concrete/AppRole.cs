using JwtSolution.Entities.Abstract;
using System.Collections.Generic;

namespace JwtSolution.Entities.Concrete
{
    public class AppRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
