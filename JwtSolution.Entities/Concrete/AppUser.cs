using JwtSolution.Entities.Abstract;
using System.Collections.Generic;

namespace JwtSolution.Entities.Concrete
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
