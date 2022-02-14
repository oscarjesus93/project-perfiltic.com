using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api_perfiltic.Helpers
{
    public class JWTHelpers
    {

        private readonly byte[] secret;

        public JWTHelpers(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(secretKey);
        }

        public string createToken(string @username)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, @username));

            var tokenDescripton = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createToken = tokenHandler.CreateToken(tokenDescripton);
            return tokenHandler.WriteToken(createToken);
        }

    }
}
