namespace OnlineBookstore.Services
{
    using OnlineBookstore.Entities;
    using OnlineBookstore.Service.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Text;
    using System.IdentityModel.Tokens.Jwt;

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key; // doesn't leave the server

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Token"]!));
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim> // create claims
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Username) // NameId will be the identifier for the token
            };
                                                               // specify security algorithms
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); // create signing creds

            // create token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            // create token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // create token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // return the written token to whoever needs it
            return tokenHandler.WriteToken(token);
        }
    }
}
