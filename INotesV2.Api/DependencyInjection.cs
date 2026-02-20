using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace INotesV2.Api
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfigurationBuilder configuration)
        {

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer(); 

            services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazor", options =>
                {
                    options.WithOrigins("https://localhost:7289", "http://localhost:5024")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },                   
                        },
                        new string[] { }
                    },
                });
            });

            configuration.AddJsonFile("appsettings.json", optional: false)
                         .AddJsonFile("appsettings.Local.json", optional: true);
                       
            return services;
        }
    }
}
