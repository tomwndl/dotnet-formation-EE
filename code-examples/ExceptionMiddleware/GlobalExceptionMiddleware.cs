namespace ExceptionMiddleware;

public class GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger) : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (Exception ex)
    {
      logger.LogCritical(ex, "Unhandled application exception");
      await HandleException(context, ex);
    }
  }

  private static async Task HandleException(HttpContext context, Exception exception)
  {
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

    var errorResponse = new
    {
      Message = "This is a user friendly message shown to user and hiding exceptions details.",
      ContactEmail = "it-support-team@axolotl.com"
    };

    await context.Response.WriteAsJsonAsync(errorResponse);
  }
}
