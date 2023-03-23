using MappingToDbEntitiesApproach.Domain.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.TechnicalObject;

public interface ITechnicalObjectRepository : IDomainRepository<TechnicalObject>
{
    Task<TechnicalObject> GetByIdAsync(Guid technicalObjectId, CancellationToken cancellationToken);
}
