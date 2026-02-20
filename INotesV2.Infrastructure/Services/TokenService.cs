using INotesV2.Application.Dtos;
using INotesV2.Application.Interfaces.Services;
using INotesV2.Domain.Common;
using INotesV2.Domain.Entities;
using INotesV2.Domain.Interfaces;
using INotesV2.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Infrastructure.Services
{
    public class TokenService(IConfiguration configuration, AppDbContext context) : ITokenService
    {

        public string CreateToken(User user)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.user_name!)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token_descriptor = new JwtSecurityToken(
                issuer: configuration["AppSettings:Issuer"],
                audience: configuration["AppSettings:Audience"],
                claims: claim,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token_descriptor);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public async Task<string> GenerateAndSaveRefreshToken(User user, CancellationToken cancellationToken = default)
        {
            var refreshToken = GenerateRefreshToken();
            user.refresh_token = refreshToken;
            user.refresh_token_expiry = DateTime.UtcNow;
            await context.SaveChangesAsync(cancellationToken);
            return refreshToken;
        }

        public async Task<User> ValidateRefreshToken(Guid UserId, string refresh_Token, CancellationToken cancellationToken = default)
        {
            var user = await context.users.FindAsync(UserId, cancellationToken);
            if (user == null || user.refresh_token != refresh_Token || user.refresh_token_expiry < DateTime.UtcNow)
            {
                return null!;
            }
            return user;
        }
        public async Task<Result<TokenResponseDto>> CreateTokenResponse(User user, CancellationToken cancellationToken = default)
        {
            var tokenResponse = new TokenResponseDto
            {
                access_token = CreateToken(user),
                refresh_token = await GenerateAndSaveRefreshToken(user, cancellationToken)
            };
            return Result<TokenResponseDto>.Success(tokenResponse);
        }
    }
}