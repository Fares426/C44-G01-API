
using E_commerce.Domain.Contracts;
using E_commerce.Persistence.DependencyInjection;
using E_commerce.Service.DependencyInjection;
using E_commerce.Web.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddApplicationServices();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
        builder.Services.AddProblemDetails();
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState.Where(x => x.Value.Errors.Count() > 0)
                .ToDictionary(x => x.Key, x => x.Value.Errors.Select(e => e.ErrorMessage).ToList());

                var problem = new ProblemDetails
                {
                    Title = "Validation Error",
                    Detail = "One or more Validation Errors Occured",
                    Status = StatusCodes.Status400BadRequest,
                    Extensions = { { "error", errors } }
                };

                return new BadRequestObjectResult(problem);
            };
        });
        var app = builder.Build();

        #region Initialize Db
        var scope = app.Services.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        await initializer.InitializeAsync();
        #endregion

        //app.UseCustomExceptionHandler();
        app.UseExceptionHandler();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseStaticFiles();

        app.MapControllers();

        app.Run();

    }
}
