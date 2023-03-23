using DirectStorageApproach.Domain.Abstractions;
using DirectStorageApproach.Domain.Aggregates.Notification;
using DirectStorageApproach.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DirectStorageApproach.Infrastructure.DomainRepositories.Notifications;

internal sealed class NotificationRepository : INotificationRepository
{
    private readonly DbSet<Notification> _notifications;

    public IUnitOfWork UnitOfWork { get; }

    public NotificationRepository(
        DatabaseContext context)
    {
        UnitOfWork = context;
        _notifications = context.Notifications;
    }

    public async Task<Notification> GetByIdAsync(Guid notificationId, CancellationToken cancellationToken)
    {
        return await _notifications
            .NotificationWithAllChildEntities()
            .FirstOrDefaultAsync(notification =>
                notification.Id == notificationId,
            cancellationToken);
    }

    public async Task CreateAsync(Notification notification, CancellationToken cancellationToken)
    {
        await _notifications.AddAsync(notification, cancellationToken);
    }

    public async Task UpdateAsync(Notification notification, CancellationToken cancellationToken)
    {
        notification.UpdateVersion();
        await Task.CompletedTask;
    }
}
