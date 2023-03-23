using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.EntityConfigurations.Notifications;

internal sealed class NotificationEntityConfiguration
    : DbEntityConfiguration<NotificationEntity, Guid>
{
    public override void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {
        base.Configure(builder);

        builder.HasQueryFilter(notification => notification.IsDeleted == false);

        builder
            .Property(notification => notification.Version)
            .IsConcurrencyToken()
            .IsRequired();

        builder
            .Property(notification => notification.Name)
            .IsRequired();

        builder
            .Property(notification => notification.Number)
            .IsRequired();

        builder
            .Property(notification => notification.DetectedAt)
            .IsRequired();

        builder
            .Property(notification => notification.CreatedAt)
            .IsRequired();

        builder
            .Property(notification => notification.CreatedBy)
            .IsRequired();

        builder.OwnsOne(notification => notification.Breakdown, subbuilder =>
        {
            subbuilder
                .Property(breakdown => breakdown.Start)
                .HasColumnName("BreakdownStart");

            subbuilder
                .Property(breakdown => breakdown.Finish)
                .HasColumnName("BreakdownFinish");

            subbuilder
                .Property(breakdown => breakdown.Duration)
                .HasColumnName("BreakdownDuration");
        });

        builder
            .HasOne(notification => notification.Status)
            .WithMany()
            .HasForeignKey(notification => notification.StatusId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(notification => notification.Comments)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(notification => notification.TechnicalObject)
            .WithMany()
            .HasForeignKey(notification => notification.TechnicalObjectId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(notification => notification.TechnicalObjects)
            .WithOne(link => link.Notification)
            .HasForeignKey(link => link.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
