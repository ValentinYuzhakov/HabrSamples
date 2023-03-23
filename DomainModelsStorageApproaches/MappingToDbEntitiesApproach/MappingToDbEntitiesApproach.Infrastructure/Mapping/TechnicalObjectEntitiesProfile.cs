using AutoMapper;
using MappingToDbEntitiesApproach.Domain.Aggregates.TechnicalObject;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.TechnicalObjects;

namespace MappingToDbEntitiesApproach.Infrastructure.Mapping;

public sealed class TechnicalObjectEntitiesProfile : Profile
{
    public TechnicalObjectEntitiesProfile()
    {
        CreateMap<TechnicalObjectEntity, TechnicalObject>(MemberList.Destination)
            .ForMember(destination => destination.DomainEvents, options => options.Ignore())
            .IncludeAllDerived();

        CreateMap<EquipmentEntity, Equipment>(MemberList.Destination)
            .IncludeBase<TechnicalObjectEntity, TechnicalObject>();

        CreateMap<FunctionalLocationEntity, FunctionalLocation>(MemberList.Destination)
            .IncludeBase<TechnicalObjectEntity, TechnicalObject>();
    }
}
