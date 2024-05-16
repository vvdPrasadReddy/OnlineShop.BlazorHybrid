using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.API.Shared.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineShop.API.Helpers
{
    public interface ITokenHelper
    {
        string CreateJWTToken(IdentityUser user);
        AuthenticationResponseDTO CreateToken(IdentityUser user);
    }
    public class TokenHelper : ITokenHelper
    {
        private readonly IConfiguration _configuration;

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJWTToken(IdentityUser user)
        {
            var claims = new Claim[]
            {
                new (JwtRegisteredClaimNames.Email, user.Email)
            };
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWTSettings:Key"] ?? string.Empty)),
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               _configuration["ApplicationSettings:JWTSettings:Issuer"],
               _configuration["ApplicationSettings:JWTSettings:Audience"],
                claims,
                null,
                DateTime.Now.AddDays(1),
                signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler()
                                    .WriteToken(token);
            return tokenValue;
        }

        public AuthenticationResponseDTO CreateToken(IdentityUser user)
        {
            var expiration = DateTime.UtcNow.AddDays(1);

            var token = CreateJWTToken(user);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new AuthenticationResponseDTO
            {
                Token = token,
                Expiration = expiration
            };
        }
    }    
}
