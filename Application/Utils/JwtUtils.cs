using Application.Abstractions.Repositories;
using Application.Commons;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Utils
{
    public static class JwtUtils
    {
        public static string GenerateJWT(this User user, JwtConfig jwtConfig)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString() ?? RoleEnum.User.ToString()),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(jwtConfig.ExpireTimeInDays),
                issuer: jwtConfig.Issuer,
                audience: jwtConfig.Audience,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
