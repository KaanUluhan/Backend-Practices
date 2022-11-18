using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();    //konfigrasyondaki alanı bul appersettingsdeki tokenoptions u al içindeki bilgilerle tokenoptions.cs dekileri matchle 

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);       //dakika ekle
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);             //securitykeyhelper onunda createsecuritykeyi var tokenoptionstaki securityi kullanarak oluşturabilirsin
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);        //algoritma ihtiyaı için signincredentialshelper var 
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);     //ilgili kullanıcı için yetkiler için method createjwt..
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)     //claim yetki 
        {
            var claims = new List<Claim>();
            
            claims.AddNameIdentifier(user.Id.ToString());   //kullanıcı adı
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());  //roller

            return claims;
        }
    }
}
