using Microsoft.AspNetCore.Builder;

namespace SMachine.API.Middlewares
{
    public static class ValidationSymbolMapsMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationSymbolMapsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationSymbolMapsMiddleware>();
        }
    }
}