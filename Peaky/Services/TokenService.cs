using Microsoft.IdentityModel.Tokens;
using Peaky.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Peaky.Services
{
    public class TokenService
    {

        public static String GenerateTokenAsString(User user) {

            var TokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.UTF8.GetBytes("fedaf7d8863b48e197b9287d492b708e"); //TODO: FIX LATER

            var TokenDescriptor = new SecurityTokenDescriptor {

                Subject = new ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name, user.name.ToString()),
                    new Claim(ClaimTypes.Email, user.email.ToString()),

                }),
                Expires = DateTime.UtcNow.AddHours(6), //TODO: PASS BY PARAMETER?
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

            };

            var token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(token);

        }

    }
}
