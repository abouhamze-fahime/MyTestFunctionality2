using Application.Interface.Token;
using Domain.Models.UserModes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{


    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserViewModel user)
        {
            var claim = new[]
                     {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWT:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                      //  new Claim("UserId" ,user.UserId.ToString()),
                        new Claim("UserName" , user.UserName),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Email, user.UserName),
                        new Claim(ClaimTypes.Role,"Admin")
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signInCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signInCredential);

            var tokenString =  new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
            //(new { token = tokenString });
        }
    }
}


