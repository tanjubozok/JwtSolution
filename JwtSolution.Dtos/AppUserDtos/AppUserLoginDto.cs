using JwtSolution.Dtos.Abstract;

namespace JwtSolution.Dtos.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
