using DirectStorageApproach.Domain.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DirectStorageApproach.Domain.Aggregates.Notification;

public interface INotificationRepository : IDomainRepository<Notification>
{
    Task<Notification> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Notification notification, CancellationToken cancellationToken);
    Task UpdateAsync(Notification notification, CancellationToken cancellationToken);
}
