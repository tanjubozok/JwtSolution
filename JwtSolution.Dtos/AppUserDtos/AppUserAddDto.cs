using JwtSolution.Dtos.Abstract;

namespace JwtSolution.Dtos.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
    }
}
