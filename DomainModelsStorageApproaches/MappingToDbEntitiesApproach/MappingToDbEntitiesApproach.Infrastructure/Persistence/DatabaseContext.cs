using MappingToDbEntitiesApproach.Domain.Abstractions;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.TechnicalObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence;

internal sealed class DatabaseContext : DbContext, IUnitOfWork
{
    public DbSet<NotificationEntity> Notifications { get; set; }
    public DbSet<TechnicalObjectEntity> TechnicalObjects { get; set; }
    public DbSet<NotificationCommentEntity> NotificationComments { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("ltree");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
