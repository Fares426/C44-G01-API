using E_commerce.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Web.Middlewares;

public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var problem = new ProblemDetails
                {
                    Title = "An unexpected error occurred - EndPoint Not Found",
                    Detail = $"End Point {context.Request.Path} was not Found",
                    Instance = context.Request.Path,
                    Status = StatusCodes.Status404NotFound
                };
                await context.Response.WriteAsJsonAsync(problem);
            }
        }
        catch (Exception ex)
        {
            //logging
            logger.LogError("Something Went Wrong !", ex.Message);


            //write response
            //set HttpResponse status code
            //Create Response Object

            var problem = new ProblemDetails
            {
                Title = "An unexpected error occurred!",
                Detail = ex.Message,
                Instance = context.Request.Path,
                Status = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                }
            };

            context.Response.StatusCode = problem.Status.Value;

            await context.Response.WriteAsJsonAsync(problem);

        }
    }
}

public static class GlobalExceptionHandlerExtensions
{
    public static WebApplication UseCustomExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();
        return app;

    }
}
