using MappingToDbEntitiesApproach.Domain.Results;
using System.Collections.Generic;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.Notification.StatusFlow;

internal sealed record Declined(int Id, string Name) : NotificationStatus(Id, Name)
{
    protected override IReadOnlySet<NotificationStatus> NextAllowedStatuses =>
        new HashSet<NotificationStatus>();

    internal override Result ValidateStatusCanBeChanged(NotificationStatus nextStatus, NotificationStatusFlowContext context)
    {
        if (StatusCanBeChangedTo(nextStatus) is false)
            return DomainErrors.Statuses.UnableToChangeStatus(Name, nextStatus.Name);

        return Result.Ok();
    }
}
