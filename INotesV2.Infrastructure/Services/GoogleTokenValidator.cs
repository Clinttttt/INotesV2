using INotesV2.Application.Interfaces.Services;
using INotesV2.Application.Models;
using INotesV2.Domain.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace INotesV2.Infrastructure.Services
{
    public class GoogleTokenValidator : IGoogleTokenValidator
    {
        private readonly HttpClient _http;
        public GoogleTokenValidator(HttpClient http)
        {
            _http = http;
        }
        public async Task<Result<GoogleUserInfo>> ValidateAsync(string id_token)
        {
            try
            {
                var response = await _http.GetAsync(
                 $"https://oauth2.googleapis.com/tokeninfo?id_token={id_token}");

                if (response is null)
                {
                    return Result<GoogleUserInfo>.NotFound();
                }

                var json = await response.Content.ReadFromJsonAsync<JsonElement>();

                return Result<GoogleUserInfo>.Success(new GoogleUserInfo
                (
                     json.GetProperty("sub").GetString()!,
                     json.GetProperty("email").GetString()!,
                     json.GetProperty("name").GetString()!,
                     json.GetProperty("picture").GetString()
                ));

            }
            catch
            {
                return Result<GoogleUserInfo>.NotFound();
            }
        }
    }
}
