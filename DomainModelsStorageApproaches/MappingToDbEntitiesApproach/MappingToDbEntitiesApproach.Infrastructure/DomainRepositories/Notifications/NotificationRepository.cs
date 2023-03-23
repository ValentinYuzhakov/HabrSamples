using AutoMapper;
using MappingToDbEntitiesApproach.Domain.Abstractions;
using MappingToDbEntitiesApproach.Domain.Aggregates.Notification;
using MappingToDbEntitiesApproach.Infrastructure.Persistence;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MappingToDbEntitiesApproach.Infrastructure.DomainRepositories.Notifications;

internal sealed class NotificationRepository : INotificationRepository
{
    private readonly IMapper _mapper;
    private readonly DbSet<NotificationEntity> _notifications;

    public IUnitOfWork UnitOfWork { get; }

    public NotificationRepository(
        IMapper mapper,
        DatabaseContext context)
    {
        _mapper = mapper;
        UnitOfWork = context;
        _notifications = context.Notifications;
    }

    public async Task<Notification> GetByIdAsync(Guid notificationId, CancellationToken cancellationToken)
    {
        var notificationEntity = await _notifications
            .NotificationWithAllChildEntities()
            .FirstOrDefaultAsync(notification =>
                notification.Id == notificationId,
            cancellationToken);

        return _mapper.Map<Notification>(notificationEntity);
    }

    public async Task CreateAsync(Notification notification, CancellationToken cancellationToken)
    {
        var notificationEntity = _mapper.Map<NotificationEntity>(notification);

        await _notifications.AddAsync(notificationEntity, cancellationToken);
    }

    public async Task UpdateAsync(Notification notification, CancellationToken cancellationToken)
    {
        var notificationEntity = await _notifications
            .FindAsync(new object[] { notification.Id }, cancellationToken);

        _mapper.Map(notification, notificationEntity);

        var notificationTechnicalObjectLinks = notification.TechnicalObjects
            .Select((technicalObjectId, index) => new NotificationTechnicalObjectLink
            {
                TechnicalObjectId = technicalObjectId,
                NotificationId = notificationEntity.Id
            })
            .ToList();

        notificationEntity.TechnicalObjects = notificationTechnicalObjectLinks;

        IncrementVersion(notificationEntity);
    }

    private static void IncrementVersion(NotificationEntity notification)
    {
        notification.Version++;
    }
}
