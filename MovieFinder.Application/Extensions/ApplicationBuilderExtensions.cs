using Microsoft.AspNetCore.Builder;
using MovieFinder.Application.Middlewares;

namespace MovieFinder.Application.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder application)
    {
        return application.UseMiddleware<ErrorHandlerMiddleware>();
    }
}