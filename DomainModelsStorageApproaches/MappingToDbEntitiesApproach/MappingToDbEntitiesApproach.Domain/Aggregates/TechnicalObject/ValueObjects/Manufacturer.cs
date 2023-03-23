using MappingToDbEntitiesApproach.Domain.Abstractions;
using System;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.TechnicalObject.ValueObjects;

public sealed record Manufacturer : ValueObject
{
    public string Name { get; init; }
    public string Country { get; init; }
    public string Model { get; init; }
    public string PartNumber { get; init; }
    public string SerialNumber { get; init; }
    public DateTimeOffset ManufacturedAt { get; init; }
}
