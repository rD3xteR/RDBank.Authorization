using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Core.Abstractions;
using Core.Options;

using Microsoft.IdentityModel.Tokens;

namespace Core.Services;

public class JwtService(JwtOptions jwtOptions) : IJwtService
{
    public string GetToken(Guid userId, string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtKey = Encoding.UTF8.GetBytes(jwtOptions.SecurityKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email)
            ]),
            Expires = DateTime.UtcNow.AddDays(7),
            Issuer = jwtOptions.Issuer,
            Audience = jwtOptions.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
