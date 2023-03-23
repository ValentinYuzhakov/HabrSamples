using DirectStorageApproach.Domain.Aggregates.Notification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DirectStorageApproach.Infrastructure.DomainRepositories.Notifications;

internal static class NotificationExtensions
{
    internal static IQueryable<Notification> NotificationWithAllChildEntities(
        this IQueryable<Notification> query)
    {
        return query
            .Include(notification => notification.CurrentStatus)
            .Include(notification => notification.Comments)
                .ThenInclude(comment => comment.FromStatus)
            .Include(notification => notification.Comments)
                .ThenInclude(comment => comment.ToStatus)
            .Include(notification => notification.TechnicalObjects);
    }
}
