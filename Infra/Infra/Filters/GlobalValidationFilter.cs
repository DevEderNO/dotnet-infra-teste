using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infra.Infra.Filters;

public class GlobalValidationFilter : IExceptionFilter, IActionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not ValidationException validationException) return;
        var errors = new Dictionary<string, string[]>
        {
            { validationException.ValidationResult.MemberNames.First(), [validationException.Message] }
        };

        var problemDetails = GetProblemDetails(errors);

        context.Result = new BadRequestObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? []
            );

        var problemDetails = GetProblemDetails(errors);

        context.Result = new BadRequestObjectResult(problemDetails);
    }

    private static ValidationProblemDetails GetProblemDetails(Dictionary<string, string[]> errors)
    {
        var problemDetails = new ValidationProblemDetails(errors)
        {
            Title = "One or more validation errors occurred.",
            Status = StatusCodes.Status400BadRequest
        };
        return problemDetails;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}