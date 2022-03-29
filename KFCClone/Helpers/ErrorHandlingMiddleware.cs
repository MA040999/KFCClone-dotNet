using System.Net;
using System.Text.Json;

namespace KFCClone.Helpers
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                switch (ex)
                {
                    case ApplicationException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(new { message = ex?.Message });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
