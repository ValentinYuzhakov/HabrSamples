using MappingToDbEntitiesApproach.Infrastructure.Mapping;
using MappingToDbEntitiesApproach.Infrastructure.Mapping.Converters;
using MappingToDbEntitiesApproach.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MappingToDbEntitiesApproach.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMappingToDbEntitiesApproachInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("MappingToDbEntitiesApproachConnectionString")));

        services.AddTransient<TimeSpanToLongConverter>();
        services.AddTransient<LongToTimeSpanConverter>();

        services.AddAutoMapper(c =>
        {
            c.AddProfile<NotificationEntitiesProfile>();
            c.AddProfile<TechnicalObjectEntitiesProfile>();
        });

        return services;
    }
}
