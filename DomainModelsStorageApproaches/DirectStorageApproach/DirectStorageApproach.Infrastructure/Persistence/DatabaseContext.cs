using DirectStorageApproach.Domain.Abstractions;
using DirectStorageApproach.Domain.Aggregates.Notification;
using DirectStorageApproach.Domain.Aggregates.TechnicalObject;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DirectStorageApproach.Infrastructure.Persistence;

internal sealed class DatabaseContext : DbContext, IUnitOfWork
{
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<TechnicalObject> TechnicalObjects { get; set; }
    public DbSet<NotificationComment> NotificationComments { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
