using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Pquyquy.WebAPI.Extensions.Services;

public static class AddWebApiService
{
    public static void AddWebApi(this IServiceCollection service)
    {
        service.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
    }
}
