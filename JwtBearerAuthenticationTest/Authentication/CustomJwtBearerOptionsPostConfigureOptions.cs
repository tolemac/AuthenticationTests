using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace JwtBearerAuthenticationTest.Authentication
{
    public class CustomJwtBearerOptionsPostConfigureOptions : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly CustomJwtTokenValidation _tokenValidator; //example dependancy

        public CustomJwtBearerOptionsPostConfigureOptions(CustomJwtTokenValidation tokenValidator)
        {
            _tokenValidator = tokenValidator;
        }

        public void PostConfigure(string name, JwtBearerOptions options)
        {
            options.SecurityTokenValidators.Clear();
            options.SecurityTokenValidators.Add(_tokenValidator);
        }
    }
}
