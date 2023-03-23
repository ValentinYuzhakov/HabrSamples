using DirectStorageApproach.Domain.Abstractions;
using System;

namespace DirectStorageApproach.Domain.Aggregates.Notification;

public sealed class NotificationComment : DomainEntity<Guid>
{
    private bool _isDeleted;
    private readonly int? _toStatusId;
    private readonly int? _fromStatusId;

    public Guid UserId { get; private set; }
    public string Comment { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public NotificationStatus FromStatus => _fromStatusId.HasValue ? NotificationStatus.GetById(_fromStatusId.Value) : null;
    public NotificationStatus ToStatus => _toStatusId.HasValue ? NotificationStatus.GetById(_toStatusId.Value) : null;

    private NotificationComment(
        Guid id,
        Guid userId,
        string comment,
        DateTimeOffset createdAt,
        int? fromStatusId,
        int? toStatusId) : base(id)
    {
        UserId = userId;
        Comment = comment;
        CreatedAt = createdAt;
        _fromStatusId = fromStatusId;
        _toStatusId = toStatusId;
    }
}
