using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.EntityConfigurations;

internal sealed class NotificationTechnicalObjectLinkConfiguration
    : IEntityTypeConfiguration<NotificationTechnicalObjectLink>
{
    public void Configure(EntityTypeBuilder<NotificationTechnicalObjectLink> builder)
    {
        builder
            .HasKey(link => new { link.TechnicalObjectId, link.NotificationId });

        builder
            .ToTable("NotificationTechnicalObjectLinks");
    }
}
