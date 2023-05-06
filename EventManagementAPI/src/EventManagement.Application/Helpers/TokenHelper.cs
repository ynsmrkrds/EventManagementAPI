﻿using EventManagement.Domain.Configurations;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace EventManagement.Application.Helpers
{
    public class TokenHelper
    {
        private static TokenHelper? _instance;
        private static IConfiguration? _configuration;
        private static IHttpContextAccessor? _httpContextAccessor;

        private TokenHelper(IHttpContextAccessor httpContextAccessor)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false);

            _configuration = builder.Build();
            _httpContextAccessor = httpContextAccessor;
        }

        public static TokenHelper Instance()
        {
            _instance ??= new(new HttpContextAccessor());

            return _instance;
        }

        public string CreateToken(UserEntity userEntity)
        {
            TokenConfiguration? tokenConfiguration = GetConfiguration();

            Claim[] claims = new[]
            {
                    new Claim("user_id", userEntity.ID.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, userEntity.Email),
                    new Claim(JwtRegisteredClaimNames.Name, userEntity.Name),
                    new Claim(JwtRegisteredClaimNames.FamilyName, userEntity.Surname),
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(tokenConfiguration!.Key));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtToken = new(
                issuer: tokenConfiguration.Issuer,
                audience: tokenConfiguration.Audience,
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(tokenConfiguration.DurationInMinutes))
            );


            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public TokenModel DecodeToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler handler = new();

                JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(token);

                string userId = jwtSecurityToken.Claims.First(x => x.Type == "user_id").Value;
                string email = jwtSecurityToken.Claims.First(x => x.Type == "email").Value;
                string name = jwtSecurityToken.Claims.First(x => x.Type == "name").Value;
                string surname = jwtSecurityToken.Claims.First(x => x.Type == "family_name").Value;

                return new TokenModel(int.Parse(userId), email, name, surname);
            }
            catch (Exception)
            {
                throw new ClientSideException(ExceptionConstants.TokenError);
            }
        }

        public string? GetTokenInRequest()
        {
            return _httpContextAccessor?.HttpContext?.Request.Headers[nameof(HttpRequestHeader.Authorization)].ToString().Replace("Bearer ", "");
        }

        public TokenModel? DecodeTokenInRequest()
        {
            string? token = GetTokenInRequest();
            if (string.IsNullOrEmpty(token)) return null;

            return DecodeToken(token);
        }

        private static TokenConfiguration? GetConfiguration()
        {
            return _configuration?.GetSection("JwtSettings").Get<TokenConfiguration>();
        }
    }
}
