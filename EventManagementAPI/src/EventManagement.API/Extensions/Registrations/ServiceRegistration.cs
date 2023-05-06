using EventManagement.Domain.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace EventManagement.API.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Sets up the authentication token configurations
            TokenConfiguration? tokenConfiguration = configuration.GetSection("JwtSettings").Get<TokenConfiguration>();
            if (tokenConfiguration != null)
            {
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.SaveToken = true;
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateActor = true,
                                ValidateLifetime = true,
                                ClockSkew = TimeSpan.Zero,
                                ValidIssuer = tokenConfiguration.Issuer,
                                ValidAudience = tokenConfiguration.Audience,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Key))
                            };
                        });
            }

            // Sets up the swagger for authentication
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rest GPT Reader"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Id="Bearer",
                                Type=ReferenceType.SecurityScheme
                            },
                            In=ParameterLocation.Header,
                            Name="Bearer"
                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
