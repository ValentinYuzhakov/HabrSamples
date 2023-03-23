using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MappingToDbEntitiesApproach.Infrastructure.DomainRepositories.Notifications;

internal static class NotificationExtensions
{
    internal static IQueryable<NotificationEntity> NotificationWithAllChildEntities(
        this IQueryable<NotificationEntity> query)
    {
        return query
            .Include(notification => notification.TechnicalObject)
            .Include(notification => notification.Status)
            .Include(notification => notification.Comments)
                .ThenInclude(comment => comment.FromStatus)
            .Include(notification => notification.Comments)
                .ThenInclude(comment => comment.ToStatus)
            .Include(notification => notification.TechnicalObjects);
    }
}
