using MappingToDbEntitiesApproach.Domain.Abstractions;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.TechnicalObject.ValueObjects;

public sealed record Weight : ValueObject
{
    public decimal Value { get; init; }
    public string Unit { get; init; }
}
