using DirectStorageApproach.Domain.Aggregates.Notification;
using DirectStorageApproach.Domain.Aggregates.TechnicalObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DirectStorageApproach.Infrastructure.Persistence.EntityConfigurations.Notifications;

internal sealed class NotificationEntityConfiguration
    : EntityConfiguration<Notification, Guid>
{
    public override void Configure(EntityTypeBuilder<Notification> builder)
    {
        base.Configure(builder);

        builder.HasQueryFilter(notification => EF.Property<bool>(notification, "_isDeleted") == false);

        builder
            .Ignore(notification => notification.DomainEvents);

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
            .Property<bool>("_isDeleted")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("IsDeleted");

        builder
            .Property<int>("_currentStatusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("StatusId");

        builder
            .HasOne<NotificationStatus>()
            .WithMany()
            .HasForeignKey("_currentStatusId")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(notification => notification.Comments)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(notification => notification.Comments)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder
            .HasOne<TechnicalObject>()
            .WithMany()
            .HasForeignKey(notification => notification.TechnicalObjectId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(notification => notification.TechnicalObjects)
            .WithOne()
            .HasForeignKey(link => link.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(notification => notification.TechnicalObjects)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
