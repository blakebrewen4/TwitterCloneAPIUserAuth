using Microsoft.AspNetCore.Builder;
using TwitterCloneAPIUserAuth.Middlewares;

namespace TwitterCloneAPIUserAuth.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
