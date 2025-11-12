using E_commerce.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Web.Handlers;

public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex, CancellationToken cancellationToken)
    {
        if (ex is NotFoundException notFound)
        {
            //logging
            logger.LogError("Something Went Wrong !", ex.Message);


            //write response
            //set HttpResponse status code
            //Create Response Object

            var problem = new ProblemDetails
            {
                Title = "An unexpected error occurred!",
                Detail = notFound.Message,
                Instance = context.Request.Path,
                Status = StatusCodes.Status404NotFound
            };

            context.Response.StatusCode = problem.Status.Value;

            await context.Response.WriteAsJsonAsync(problem, cancellationToken);

            return true;
        }
        return false;
    }
}
