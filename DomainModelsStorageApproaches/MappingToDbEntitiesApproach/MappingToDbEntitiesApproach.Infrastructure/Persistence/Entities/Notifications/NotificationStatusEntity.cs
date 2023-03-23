namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;

internal sealed class NotificationStatusEntity : DbEntity<int>
{
    public string Name { get; set; }
}