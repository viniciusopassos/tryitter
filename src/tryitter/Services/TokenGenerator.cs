using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using tryitter.Models;

namespace tryitter.Services
{
    public class TokenGenerator
    {
        private string Secret = "2d74025e7bcf058897d8daaa99ae99b5";
        public string Generate(Student student)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(student),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)), 
                SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(10)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity AddClaims(Student student)
        {
            var instance = new ClaimsIdentity();

            instance.AddClaim(new Claim(student.Name, student.StudentId.ToString()));
            
            return instance;
        }
    }
}