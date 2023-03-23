using MappingToDbEntitiesApproach.Domain.Abstractions;
using MappingToDbEntitiesApproach.Domain.Aggregates.Notification.ValueObjects;
using System;
using System.Collections.Generic;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.Notification;

public sealed class Notification : AggregateRoot
{
    private readonly List<Guid> _technicalObjects;
    private readonly List<NotificationComment> _comments;

    public string Name { get; private set; }
    public long Number { get; private set; }
    public DateTimeOffset DetectedAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? CompletedAt { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid? Executor { get; private set; }
    public Guid TechnicalObjectId { get; private set; }
    public Breakdown Breakdown { get; private set; }
    public NotificationStatus CurrentStatus { get; private set; }

    public IReadOnlyCollection<NotificationComment> Comments => _comments;
    public IReadOnlyCollection<Guid> TechnicalObjects => _technicalObjects;

    private Notification(
        Guid id,
        string name,
        long number,
        DateTimeOffset detectedAt,
        DateTimeOffset createdAt,
        DateTimeOffset? completedAt,
        Guid createdBy,
        Guid technicalObjectId) : base(id)
    {
        Name = name;
        Number = number;
        DetectedAt = detectedAt;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        CompletedAt = completedAt;
        TechnicalObjectId = technicalObjectId;
        CurrentStatus = NotificationStatus.New;

        _comments = new();
        _technicalObjects = new();
    }
}
