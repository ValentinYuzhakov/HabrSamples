using System;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;

internal sealed class NotificationCommentEntity : DbEntity<Guid>
{
    public Guid UserId { get; set; }
    public string Comment { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int? FromStatusId { get; set; }
    public NotificationStatusEntity FromStatus { get; set; }
    public int? ToStatusId { get; set; }
    public NotificationStatusEntity ToStatus { get; set; }
    public bool IsDeleted { get; set; }
}
