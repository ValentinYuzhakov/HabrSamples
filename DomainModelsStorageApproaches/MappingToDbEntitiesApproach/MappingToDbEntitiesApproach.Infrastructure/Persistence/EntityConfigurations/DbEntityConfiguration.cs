using MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.EntityConfigurations;

internal abstract class DbEntityConfiguration<TDbEntity, TIdentifier>
    : IEntityTypeConfiguration<TDbEntity> where TDbEntity : DbEntity<TIdentifier>
{
    public virtual void Configure(EntityTypeBuilder<TDbEntity> builder)
    {
        builder
            .HasKey(entity => entity.Id);

        builder
            .Property(entity => entity.Id)
            .ValueGeneratedNever()
            .IsRequired();
    }
}
