using E_commerce.ServiceAbstraction.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_commerce.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class APIBaseController : ControllerBase
{
    protected IActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
        {
            return NoContent();
        }
        return Problem(result.Errors);
    }

    protected ActionResult<T> HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }

    private ActionResult Problem(IReadOnlyList<Error> errors)
    {
        if (errors.Count == 0)
            return Problem(statusCode: 500, title: "Unexpected error occured");

        if (errors.All(e => e.Type == ErrorType.Validation))
            return HandleValidationProblemError(errors);

        return HandleSingleProblemError(errors[0]);
    }

    private ActionResult HandleSingleProblemError(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description, type: error.Code);
    }
    private ActionResult HandleValidationProblemError(IReadOnlyList<Error> errors)
    {
        var modelState = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }
        return ValidationProblem(modelState);
    }
}