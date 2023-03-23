using DirectStorageApproach.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DirectStorageApproach.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDirectStorageApproachInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("DirectStorageApproachConnectionString")));

        return services;
    }
}
