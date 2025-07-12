using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var errorDetails = $"[{DateTime.Now}] {context.Exception.Message}\n";
        File.AppendAllText("logs.txt", errorDetails);

        context.Result = new ObjectResult("Internal server error")
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
