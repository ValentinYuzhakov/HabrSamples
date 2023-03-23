using DirectStorageApproach.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectStorageApproach.Infrastructure.Persistence.EntityConfigurations;

internal abstract class EntityConfiguration<TEntity, TIdentifier>
    : IEntityTypeConfiguration<TEntity> where TEntity : DomainEntity<TIdentifier>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(entity => entity.Id);

        builder
            .Property(entity => entity.Id)
            .ValueGeneratedNever()
            .IsRequired();
    }
}
