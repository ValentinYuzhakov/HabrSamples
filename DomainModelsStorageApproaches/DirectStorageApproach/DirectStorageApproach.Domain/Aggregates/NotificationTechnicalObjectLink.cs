using System;

namespace DirectStorageApproach.Domain.Aggregates;

public sealed class NotificationTechnicalObjectLink
{
    public Guid TechnicalObjectId { get; set; }
    public Guid NotificationId { get; set; }
}
