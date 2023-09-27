using AutoMapper;
using InvoicingPlan.Model;
using Microsoft.IdentityModel.Tokens;
using MoSocioAPI.DTO;
using MoSocioAPI.Shared;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoSocioAPI.Services
{
    public class TokenService
    {
        public string GeneratorToken(UserDto userDto)
        {
            var userEntity = Mapper.Map<User>(userDto); 

            var handler = new JwtSecurityTokenHandler(); 

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ConfigurateCredential.secretKey));

            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = signin,
                Subject = GenerateClaim(userEntity)
            };

            var toke = handler.CreateToken(descriptor);

            return handler.WriteToken(toke); 
        }
        private ClaimsIdentity GenerateClaim(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            ci.AddClaim(new Claim(ClaimTypes.GivenName, user.FullName));

            foreach (var role in user.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role.Name)); 

            return ci;
        }
    }
}
