using BubberDinner.Application;
using BubberDinner.Infrastructure;
using BubberDinner.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    /*builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ErrorHandlingFilterAttribute>();
    });*/
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleWare>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


