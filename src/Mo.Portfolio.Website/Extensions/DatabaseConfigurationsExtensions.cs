using Microsoft.EntityFrameworkCore;
using Mo.Portfolio.Website.Data;

namespace Mo.Portfolio.Website.Extensions;

public static class DatabaseConfigurationsExtensions
{
    public static IServiceCollection ConfigureDbContext(
        this IServiceCollection services,
        IConfiguration configurations)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configurations.GetConnectionString("DefaultConnection")));

        return services;
    }

}