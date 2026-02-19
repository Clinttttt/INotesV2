using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
                cfg.AddOpenBehavior(typeof(Behaviors.ValidationBehavior<,>));
            });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutomapperProfile>();
            });



            return services;
        }
    }
}
