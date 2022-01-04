using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JwtBearerAuthenticationTest.Authentication
{
    public class CustomJwtTokenValidation : JwtSecurityTokenHandler
    {
        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            var baseResult = base.ValidateToken(token, validationParameters, out validatedToken);
                       
            
            ((ClaimsIdentity)baseResult.Identity).AddClaim(new Claim("Hola", "Amigo"));
            
            return baseResult;
        }

    }
}
