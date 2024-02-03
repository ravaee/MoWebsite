namespace Mo.Portfolio.Website.Extensions;

public static class ApplicationConfigurationsExtensions
{
    public static IServiceCollection ConfigureAspNetServices(
        this IServiceCollection services)
    {
        services.AddRazorPages();

        return services;
    }

}