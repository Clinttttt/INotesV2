using INotesV2.Application.Dtos;
using INotesV2.Application.Interfaces.Services;
using INotesV2.Domain.Common;
using INotesV2.Domain.Interfaces;
using INotesV2.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Infrastructure.Services
{
    public class AuthService(ITokenService tokenService, IGoogleTokenValidator validator, AppDbContext context, IHttpClientFactory _httpClient) : IAuthService
    {
        public async Task<Result<TokenResponseDto>> GoogleLogin(string id_token, CancellationToken cancellationToken = default)
        {
            var google_user = await validator.ValidateAsync(id_token);

            if (google_user is null)
            {
                return Result<TokenResponseDto>.Unauthorized();
            }
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var user = await context.users.FirstOrDefaultAsync(s => s.email == google_user.value!.Email);

                if (user is null)
                {

                    var base_username = google_user.value!.Email.Split('@')[0];
                    var username = base_username;
                    var counter = 1;

                    while (await context.users.AnyAsync(s => s.user_name == username))
                    {
                        username = $"{base_username}{counter}";
                        counter++;
                    }

                    byte[]? photo_byte  = null;
                    if(google_user.value.Picture is not null)
                    
                    {
                        using var httpClient = _httpClient.CreateClient();
                        photo_byte = await httpClient.GetByteArrayAsync(google_user.value.Picture);
                    }

                    user = new Domain.Entities.User
                    {
                        email = google_user.value!.Email,
                        user_name = username,
                        provider = "Google",
                        provider_id = google_user.value.Sub,
                        created_at = DateTime.UtcNow,
                        profile_photo_url = google_user.value.Picture,
                        profile_photo_bytes = photo_byte,
                    };

                    context.users.Add(user);
                    await context.SaveChangesAsync(cancellationToken);
                }

                var token = await tokenService.CreateTokenResponse(user);
                await transaction.CommitAsync(cancellationToken);
                return token;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
           
        }

    }
}
