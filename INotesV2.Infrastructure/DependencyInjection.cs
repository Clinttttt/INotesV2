using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Application.Interfaces.Services;
using INotesV2.Domain.Interfaces;
using INotesV2.Infrastructure.Persistence;
using INotesV2.Infrastructure.Respository;
using INotesV2.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
      
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddHttpClient<IGoogleTokenValidator, GoogleTokenValidator>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INoteRespository, NoteRespository>();

            return services;
        }
    }
}
