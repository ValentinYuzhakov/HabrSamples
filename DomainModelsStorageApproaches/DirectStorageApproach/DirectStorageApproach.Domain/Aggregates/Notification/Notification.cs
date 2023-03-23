using DirectStorageApproach.Domain.Abstractions;
using DirectStorageApproach.Domain.Aggregates.Notification.ValueObjects;
using System;
using System.Collections.Generic;

namespace DirectStorageApproach.Domain.Aggregates.Notification;

public sealed class Notification : AggregateRoot
{
    private bool _isDeleted;
    private int _currentStatusId;
    private readonly List<NotificationComment> _comments;
    private readonly List<NotificationTechnicalObjectLink> _technicalObjects;

    public string Name { get; private set; }
    public long Number { get; private set; }
    public DateTimeOffset DetectedAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? CompletedAt { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid? Executor { get; private set; }
    public Guid TechnicalObjectId { get; private set; }
    public Breakdown Breakdown { get; private set; }
    public NotificationStatus CurrentStatus => NotificationStatus.GetById(_currentStatusId);
    public uint Version { get; private set; }

    public IReadOnlyCollection<NotificationComment> Comments => _comments;
    public IReadOnlyCollection<NotificationTechnicalObjectLink> TechnicalObjects => _technicalObjects;

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

        _currentStatusId = NotificationStatus.New.Id;
        _comments = new();
        _technicalObjects = new();
        Version = 1;
    }

    public void UpdateVersion()
    {
        Version++;
    }
}
