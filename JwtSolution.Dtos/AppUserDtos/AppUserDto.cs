using JwtSolution.Dtos.Abstract;
using System.Collections.Generic;

namespace JwtSolution.Dtos.AppUserDtos
{
    public class AppUserDto : IDto
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
