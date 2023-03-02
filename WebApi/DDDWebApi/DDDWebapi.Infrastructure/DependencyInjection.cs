using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebApi.Infrastructure.Authentication;
using DDDWebapi.Application.Common.Interfaces.Authentication;

namespace DDDWebapi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration
            )
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}