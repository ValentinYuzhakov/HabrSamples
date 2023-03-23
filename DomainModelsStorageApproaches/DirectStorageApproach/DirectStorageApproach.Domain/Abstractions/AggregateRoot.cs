using System;
using System.Collections.Generic;

namespace DirectStorageApproach.Domain.Abstractions;

public abstract class AggregateRoot : DomainEntity<Guid>
{
    private readonly List<IDomainEvent> _domainEvents;

    protected AggregateRoot(Guid id) : base(id) { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents =>
        _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);

    protected void ClearDomainEvents() =>
        _domainEvents.Clear();
}
