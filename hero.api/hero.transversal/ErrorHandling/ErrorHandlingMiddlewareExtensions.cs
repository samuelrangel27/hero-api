using System;
using Microsoft.AspNetCore.Builder;

namespace hero.transversal.ErrorHandling
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
