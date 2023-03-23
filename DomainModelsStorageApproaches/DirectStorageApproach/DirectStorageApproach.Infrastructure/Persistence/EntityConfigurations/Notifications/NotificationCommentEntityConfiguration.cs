using DirectStorageApproach.Domain.Aggregates.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DirectStorageApproach.Infrastructure.Persistence.EntityConfigurations.Notifications;

internal sealed class NotificationCommentEntityConfiguration
    : EntityConfiguration<NotificationComment, Guid>
{
    public override void Configure(EntityTypeBuilder<NotificationComment> builder)
    {
        base.Configure(builder);

        builder.HasQueryFilter(comment => EF.Property<bool>(comment, "_isDeleted") == false);

        builder
            .Property(comment => comment.Comment)
            .IsRequired();

        builder
            .Property<bool>("_isDeleted")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("IsDeleted");

        builder
            .Property<int?>("_fromStatusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("FromStatusId");

        builder
            .Property<int?>("_toStatusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ToStatusId");

        builder
            .HasOne<NotificationStatus>()
            .WithMany()
            .HasForeignKey("_fromStatusId")
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne<NotificationStatus>()
            .WithMany()
            .HasForeignKey("_toStatusId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
