using JwtSolution.Dtos.Abstract;

namespace JwtSolution.Dtos.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}
