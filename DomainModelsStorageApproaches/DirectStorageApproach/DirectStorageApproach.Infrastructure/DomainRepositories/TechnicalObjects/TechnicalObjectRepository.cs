using DirectStorageApproach.Domain.Abstractions;
using DirectStorageApproach.Domain.Aggregates.TechnicalObject;
using DirectStorageApproach.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DirectStorageApproach.Infrastructure.DomainRepositories.TechnicalObjects;

internal sealed class TechnicalObjectRepository : ITechnicalObjectRepository
{
    private readonly DbSet<TechnicalObject> _technicalObjects;
    public IUnitOfWork UnitOfWork { get; }

    public TechnicalObjectRepository(
        DatabaseContext context)
    {
        UnitOfWork = context;
        _technicalObjects = context.TechnicalObjects;
    }

    public async Task<TechnicalObject> GetByIdAsync(
        Guid technicalObjectId, CancellationToken cancellationToken)
    {
        return await _technicalObjects
            .Include(technicalObject => technicalObject.Children)
            .FirstOrDefaultAsync(technicalObject =>
                technicalObject.Id == technicalObjectId,
                cancellationToken);
    }
}
