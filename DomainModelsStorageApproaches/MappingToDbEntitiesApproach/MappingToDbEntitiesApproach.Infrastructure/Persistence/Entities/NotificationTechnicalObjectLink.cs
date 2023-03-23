using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.TechnicalObjects;
using System;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities;

internal sealed class NotificationTechnicalObjectLink
{
    public Guid TechnicalObjectId { get; set; }
    public TechnicalObjectEntity TechnicalObject { get; set; }
    public Guid NotificationId { get; set; }
    public NotificationEntity Notification { get; set; }
}
