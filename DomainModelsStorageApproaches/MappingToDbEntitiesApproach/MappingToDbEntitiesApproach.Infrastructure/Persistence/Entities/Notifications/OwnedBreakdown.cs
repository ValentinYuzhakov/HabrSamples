using System;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;

internal sealed class OwnedBreakdown
{
    public DateTimeOffset? Start { get; set; }
    public DateTimeOffset? Finish { get; set; }
    public long? Duration { get; set; }
}
