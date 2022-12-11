using JwtSolution.Business.Abstract;
using JwtSolution.Business.StringInfos;
using JwtSolution.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtSolution.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        public string GenerateJwt(AppUser appUser, List<AppRole> roles)
        {
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: JwtInfo.Issuer,
                audience: JwtInfo.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtInfo.TokenExpiration),
                signingCredentials: signingCredentials,
                claims: GetClaims(appUser, roles)
                );
            JwtSecurityTokenHandler handler = new();

            return handler.WriteToken(jwtSecurityToken);
        }

        private static List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, appUser.Username),
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString())
            };

            if (roles?.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            return claims;
        }
    }
}
