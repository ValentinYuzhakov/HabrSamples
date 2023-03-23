namespace MappingToDbEntitiesApproach.Domain.Abstractions;

public interface IDomainRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
