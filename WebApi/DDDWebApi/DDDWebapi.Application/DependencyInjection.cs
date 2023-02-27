using Microsoft.Extensions.DependencyInjection;
using DDDWebapi.Application.Services.Authentication;

namespace DDDWebapi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}