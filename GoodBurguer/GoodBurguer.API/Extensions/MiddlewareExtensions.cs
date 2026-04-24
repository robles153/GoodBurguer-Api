using GoodBurguer.GoodBurguer.API.Middlewares;

namespace GoodBurguer.GoodBurguer.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
