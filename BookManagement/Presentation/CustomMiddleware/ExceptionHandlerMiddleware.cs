using System.Net;

public class ExceptionHandlerMiddleware
{
  private readonly RequestDelegate _next;
  public ExceptionHandlerMiddleware(RequestDelegate next)
  {
    _next = next;
  }
  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception ex)
    {
      await HandleExceptionAsync(context, ex);
    }
  }

  private async Task HandleExceptionAsync(HttpContext context, Exception ex)
  {
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    await context.Response.WriteAsync("An unexpected error occurred.");
  }
}
