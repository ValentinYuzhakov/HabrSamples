using AutoMapper;
using MappingToDbEntitiesApproach.Domain.Abstractions;
using MappingToDbEntitiesApproach.Domain.Aggregates.TechnicalObject;
using MappingToDbEntitiesApproach.Infrastructure.Persistence;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.TechnicalObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MappingToDbEntitiesApproach.Infrastructure.DomainRepositories.TechnicalObjects;

internal sealed class TechnicalObjectRepository : ITechnicalObjectRepository
{
    private readonly IMapper _mapper;
    private readonly DbSet<TechnicalObjectEntity> _technicalObjects;
    public IUnitOfWork UnitOfWork { get; }

    public TechnicalObjectRepository(
        IMapper mapper,
        DatabaseContext context)
    {
        _mapper = mapper;
        UnitOfWork = context;
        _technicalObjects = context.TechnicalObjects;
    }

    public async Task<TechnicalObject> GetByIdAsync(
        Guid technicalObjectId, CancellationToken cancellationToken)
    {
        var technicalObjectEntity = await _technicalObjects
            .Include(technicalObject => technicalObject.Children)
            .FirstOrDefaultAsync(technicalObject =>
                technicalObject.Id == technicalObjectId,
                cancellationToken);

        return _mapper.Map<TechnicalObject>(technicalObjectEntity);
    }
}
