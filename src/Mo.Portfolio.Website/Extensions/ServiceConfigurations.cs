using Mo.Portfolio.Website.Services;
using Mo.Portfolio.Website.Services.Abstractions;

namespace Mo.Portfolio.Website.Extensions;

public static class ServiceConfigurations
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IGroupService, GroupService>();

        return services;
    }
}