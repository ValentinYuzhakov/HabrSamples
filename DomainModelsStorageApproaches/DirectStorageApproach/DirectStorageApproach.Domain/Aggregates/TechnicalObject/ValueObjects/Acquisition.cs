using DirectStorageApproach.Domain.Abstractions;
using System;

namespace DirectStorageApproach.Domain.Aggregates.TechnicalObject.ValueObjects;

public sealed record Acquisition : ValueObject
{
    public decimal Price { get; init; }
    public string Currency { get; init; }
    public DateTimeOffset Date { get; init; }
}
