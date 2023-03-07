using DDDWebapi.Api.Filters;
using DDDWebapi.Api.MiddleWare;
using DDDWebapi.Application;
using DDDWebapi.Infrastructure;

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
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleWare>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseRouting();
    app.MapControllers();
    app.Run();
}