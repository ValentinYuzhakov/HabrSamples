using MappingToDbEntitiesApproach.Domain.Abstractions;
using System;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.Notification;

public sealed class NotificationComment : DomainEntity<Guid>
{
    public Guid UserId { get; private set; }
    public string Comment { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public NotificationStatus FromStatus { get; private set; }
    public NotificationStatus ToStatus { get; private set; }

    private NotificationComment(
        Guid id,
        Guid userId,
        string comment,
        DateTimeOffset createdAt,
        NotificationStatus fromStatus = null,
        NotificationStatus toStatus = null) : base(id)
    {
        UserId = userId;
        Comment = comment;
        CreatedAt = createdAt;
        FromStatus = fromStatus;
        ToStatus = toStatus;
    }
}
