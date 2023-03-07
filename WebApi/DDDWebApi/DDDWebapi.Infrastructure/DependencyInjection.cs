using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApi.Infrastructure.Authentication;
using DDDWebapi.Application.Common.Interfaces.Authentication;
using DDDWebapi.Application.Common.Interfaces.Persistance;
using DDDWebapi.Application.Common.Interfaces.Objects;
using DDDWebapi.Infrastructure.Persistance;
using DDDWebapi.Infrastructure.Objects;

namespace DDDWebapi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                this IServiceCollection services,
                ConfigurationManager configuration
            )
        {
             services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HahnDatabase")));



            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}