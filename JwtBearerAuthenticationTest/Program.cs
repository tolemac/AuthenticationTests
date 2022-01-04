using JwtBearerAuthenticationTest;
using JwtBearerAuthenticationTest.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();

var key = "Secret key to generate tokens. Alabulieeee!";

// https://jasonwatmore.com/post/2021/12/14/net-6-jwt-authentication-tutorial-with-example-api

builder.Services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, CustomJwtBearerOptionsPostConfigureOptions>();
builder.Services.AddSingleton<CustomJwtTokenValidation>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x => {
        x.SaveToken = true;        
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false            
        };
    });

builder.Services.Configure<AppSettings>(s => s.Secret = key);

builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
