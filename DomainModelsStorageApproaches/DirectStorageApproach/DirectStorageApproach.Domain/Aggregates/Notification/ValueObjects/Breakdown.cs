using DirectStorageApproach.Domain.Abstractions;
using System;

namespace DirectStorageApproach.Domain.Aggregates.Notification.ValueObjects;

public sealed record Breakdown : ValueObject
{
    public DateTimeOffset? Start { get; private set; }
    public DateTimeOffset? Finish { get; private set; }
    public TimeSpan? Duration { get; private set; }

    private Breakdown(
        DateTimeOffset? start,
        DateTimeOffset? finish,
        TimeSpan? duration)
    {
        Start = start;
        Finish = finish;
        Duration = duration;
    }
}
