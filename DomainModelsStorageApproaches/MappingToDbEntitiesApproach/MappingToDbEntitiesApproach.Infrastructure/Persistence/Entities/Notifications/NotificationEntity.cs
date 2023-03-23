using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.TechnicalObjects;
using System;
using System.Collections.Generic;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;

internal sealed class NotificationEntity : DbEntity<Guid>
{
    public string Name { get; set; }
    public long Number { get; set; }
    public OwnedBreakdown Breakdown { get; set; }
    public DateTimeOffset DetectedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? Executor { get; set; }
    public uint Version { get; set; }
    public bool IsDeleted { get; set; }

    public int StatusId { get; set; }
    public NotificationStatusEntity Status { get; set; }

    public Guid TechnicalObjectId { get; set; }
    public TechnicalObjectEntity TechnicalObject { get; }

    public ICollection<NotificationCommentEntity> Comments { get; set; }
    public ICollection<NotificationTechnicalObjectLink> TechnicalObjects { get; set; }
}
