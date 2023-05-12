using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SpaceXLaunchService.Api.Middlewares;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSingleton<ExceptionHandlingMiddleware>();
        _ = services.AddHttpContextAccessor();
        _ = services.AddHealthChecks();
        _ = services.AddAuthentication();
        _ = services.AddAuthorization();
        _ = services.AddFastEndpoints();

        // Customise default API behaviour
        _ = services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

        return services;
    }
}
