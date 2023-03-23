using DirectStorageApproach.Domain.Aggregates.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectStorageApproach.Infrastructure.Persistence.EntityConfigurations.Notifications;

internal sealed class NotificationStatusEntityConfiguration
    : IEntityTypeConfiguration<NotificationStatus>
{
    public void Configure(EntityTypeBuilder<NotificationStatus> builder)
    {
        builder
            .HasKey(status => status.Id);

        builder
            .Property(status => status.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(status => status.Name)
            .IsRequired();

        builder
            .ToTable("NotificationStatuses")
            .HasData(NotificationStatus.GetAll());
    }
}
