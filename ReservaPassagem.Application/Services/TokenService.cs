using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReservaPassagem.Application.Interface;
using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Domain.Entities.Base;

namespace ReservaPassagem.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private const int HoursToExpireToken = 2;
    public string GerenteToken(User user)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secret") ?? String.Empty);
        SecurityTokenDescriptor tokenSpecificationDescriptor = DescribeTokenSpecification(user, key);
        SecurityToken securityToken = tokenHandler.CreateToken(tokenSpecificationDescriptor);
        string token = tokenHandler.WriteToken(securityToken);
        return token;
    }
    private SecurityTokenDescriptor DescribeTokenSpecification(User user, byte[] key)
    {
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = ConfigureClaimsIdentity(user),
            Expires = DateTime.UtcNow.AddHours(HoursToExpireToken),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenDescriptor;
    }

    private ClaimsIdentity ConfigureClaimsIdentity(User user)
    {
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, user.Email.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        });
        return claimsIdentity;
    }
    
}