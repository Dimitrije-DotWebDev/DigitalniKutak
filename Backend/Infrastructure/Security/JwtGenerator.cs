using Application.Interfaces;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Infrastructure.Security
{
    public class JwtGenerator : IJwtGenerator{
        public string CreateToken(Korisnik korisnik)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, korisnik.UserName)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super tajni kljuc za jwt token test verzija za skolski projekat digitalni kutak"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}