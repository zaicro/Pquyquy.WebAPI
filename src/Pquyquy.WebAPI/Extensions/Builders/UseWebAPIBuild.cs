using Microsoft.AspNetCore.Builder;
using Pquyquy.WebAPI.Middlewares;

namespace Pquyquy.WebAPI.Extensions.Builders;

public static class UseWebAPIBuild
{
    public static void UseWebAPIMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
