using MappingToDbEntitiesApproach.Domain.Abstractions;
using MappingToDbEntitiesApproach.Domain.Aggregates.Notification.StatusFlow;
using MappingToDbEntitiesApproach.Domain.Results;
using System.Collections.Generic;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.Notification;

public abstract record NotificationStatus(int Id, string Name)
    : Enumeration<NotificationStatus>(Id, Name)
{
    protected abstract IReadOnlySet<NotificationStatus> NextAllowedStatuses { get; }

    public static NotificationStatus New => new New(1, nameof(New));
    public static NotificationStatus Declined => new Declined(2, nameof(Declined));
    public static NotificationStatus InProgress => new InProgress(3, nameof(InProgress));
    public static NotificationStatus ActionRequired => new ActionRequired(4, nameof(ActionRequired));
    public static NotificationStatus Resubmitted => new Resubmitted(5, nameof(Resubmitted));
    public static NotificationStatus Done => new Done(6, nameof(Done));

    internal abstract Result ValidateStatusCanBeChanged(NotificationStatus nextStatus, NotificationStatusFlowContext context);
    protected bool StatusCanBeChangedTo(NotificationStatus nextStatus) => NextAllowedStatuses.Contains(nextStatus);
}
