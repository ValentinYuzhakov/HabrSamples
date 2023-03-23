using DirectStorageApproach.Domain.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DirectStorageApproach.Domain.Aggregates.TechnicalObject;

public interface ITechnicalObjectRepository : IDomainRepository<TechnicalObject>
{
    Task<TechnicalObject> GetByIdAsync(Guid technicalObjectId, CancellationToken cancellationToken);
}
