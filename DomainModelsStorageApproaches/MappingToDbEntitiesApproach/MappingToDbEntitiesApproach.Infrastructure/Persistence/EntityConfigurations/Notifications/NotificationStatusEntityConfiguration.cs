using MappingToDbEntitiesApproach.Domain.Aggregates.Notification;
using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.EntityConfigurations.Notifications;

internal sealed class NotificationStatusEntityConfiguration
    : DbEntityConfiguration<NotificationStatusEntity, int>
{
    public override void Configure(EntityTypeBuilder<NotificationStatusEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(status => status.Name)
            .IsRequired();

        builder
            .ToTable("NotificationStatuses")
            .HasData(NotificationStatus.GetAll()
                .Select(status => new
                {
                    status.Id,
                    status.Name
                }));
    }
}
