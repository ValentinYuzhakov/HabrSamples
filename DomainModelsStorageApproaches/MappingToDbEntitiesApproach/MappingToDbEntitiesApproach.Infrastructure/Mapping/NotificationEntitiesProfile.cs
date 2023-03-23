using AutoMapper;
using MappingToDbEntitiesApproach.Domain.Aggregates.Notification;
using MappingToDbEntitiesApproach.Domain.Aggregates.Notification.ValueObjects;
using MappingToDbEntitiesApproach.Infrastructure.Mapping.Converters;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using System;
using System.Linq;

namespace MappingToDbEntitiesApproach.Infrastructure.Mapping;

public sealed class NotificationEntitiesProfile : Profile
{
    public NotificationEntitiesProfile()
    {
        CreateMap<NotificationEntity, Notification>(MemberList.Destination)
            .ForMember(destination => destination.TechnicalObjects, options => options
                .MapFrom(source => source.TechnicalObjects.Select(link => link.TechnicalObjectId)))
            .ForMember(destination => destination.DomainEvents, config => config.Ignore())
            .ForMember(destination => destination.CurrentStatus, config => config
                .MapFrom(source => NotificationStatus.GetById(source.StatusId)));

        CreateMap<OwnedBreakdown, Breakdown>(MemberList.Destination);
        CreateMap<Breakdown, OwnedBreakdown>(MemberList.Destination);

        CreateMap<TimeSpan?, long?>(MemberList.Destination)
            .ConvertUsing<TimeSpanToLongConverter>();

        CreateMap<long?, TimeSpan?>(MemberList.Destination)
            .ConvertUsing<LongToTimeSpanConverter>();

        CreateMap<Notification, NotificationEntity>(MemberList.Destination)
            .ForMember(destination => destination.StatusId, options => options
                .MapFrom(source => source.CurrentStatus.Id))
            .ForMember(destination => destination.Status, options => options.Ignore())
            .ForMember(destination => destination.TechnicalObjects, options => options.Ignore())
            .ForMember(destination => destination.Version, options => options.Ignore())
            .ForMember(destination => destination.IsDeleted, options => options.Ignore());

        CreateMap<NotificationCommentEntity, NotificationComment>(MemberList.Destination)
            .ForMember(destination => destination.FromStatus, options => options
                .MapFrom(source => source.FromStatusId.HasValue
                    ? NotificationStatus.GetById(source.FromStatusId.Value)
                    : null))
            .ForMember(destination => destination.ToStatus, options => options
                .MapFrom(source => source.ToStatusId.HasValue
                    ? NotificationStatus.GetById(source.ToStatusId.Value)
                    : null));

        CreateMap<NotificationStatusEntity, NotificationStatus>(MemberList.Destination);

        CreateMap<NotificationComment, NotificationCommentEntity>(MemberList.Destination)
            .ForMember(destination => destination.FromStatusId, options => options
                .MapFrom(source => source.FromStatus.Id))
            .ForMember(destination => destination.ToStatusId, options => options
                .MapFrom(source => source.ToStatus.Id))
            .ForMember(destination => destination.FromStatus, options => options.Ignore())
            .ForMember(destination => destination.ToStatus, options => options.Ignore())
            .ForMember(destination => destination.IsDeleted, options => options.Ignore());
    }
}
