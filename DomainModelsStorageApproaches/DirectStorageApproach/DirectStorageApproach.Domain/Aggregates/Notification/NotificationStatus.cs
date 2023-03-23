using DirectStorageApproach.Domain.Abstractions;

namespace DirectStorageApproach.Domain.Aggregates.Notification;

public sealed record NotificationStatus(int Id, string Name)
    : Enumeration<NotificationStatus>(Id, Name)
{
    public static NotificationStatus New => new(1, nameof(New));
    public static NotificationStatus Declined => new(2, nameof(Declined));
    public static NotificationStatus InProgress => new(3, nameof(InProgress));
    public static NotificationStatus ActionRequired => new(4, nameof(ActionRequired));
    public static NotificationStatus Resubmitted => new(5, nameof(Resubmitted));
    public static NotificationStatus Done => new(6, nameof(Done));
}
