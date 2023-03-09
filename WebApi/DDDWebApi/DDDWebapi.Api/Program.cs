using System.Text;
using DDDWebapi.Api.Filters;
using DDDWebapi.Api.MiddleWare;
using DDDWebapi.Application;
using DDDWebapi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ErrorHandlingFilterAttribute>();
    });

    //use jwt authentication
    string? jwtSecret = builder.Configuration["JwtSettings:SecretKey"];
    byte[] key = Encoding.ASCII.GetBytes(jwtSecret ?? throw new InvalidOperationException("JWT secret key is not configured."));

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    //use cors
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAnyOrigin", builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .WithMethods("POST")
                .WithMethods("GET")
                .WithMethods("DELETE")
                .WithMethods("PUT")
                .WithExposedHeaders("Access-Control-Allow-Origin")
                .WithExposedHeaders("Access-Control-Allow-Headers")
                .WithExposedHeaders("Access-Control-Allow-Methods");
        });
    });
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleWare>();
    app.UseCors("AllowAnyOrigin");
    //app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.Run();
}