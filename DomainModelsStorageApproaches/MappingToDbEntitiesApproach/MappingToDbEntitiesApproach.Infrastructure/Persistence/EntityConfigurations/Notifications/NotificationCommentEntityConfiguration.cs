using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.EntityConfigurations.Notifications;

internal sealed class NotificationCommentEntityConfiguration
    : DbEntityConfiguration<NotificationCommentEntity, Guid>
{
    public override void Configure(EntityTypeBuilder<NotificationCommentEntity> builder)
    {
        base.Configure(builder);

        builder.HasQueryFilter(comment => comment.IsDeleted == false);

        builder
            .Property(comment => comment.Comment)
            .IsRequired();

        builder
            .HasOne(comment => comment.FromStatus)
            .WithMany()
            .HasForeignKey(comment => comment.FromStatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(comment => comment.ToStatus)
            .WithMany()
            .HasForeignKey(comment => comment.ToStatusId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
