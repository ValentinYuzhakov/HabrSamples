using DirectStorageApproach.Domain.Aggregates.TechnicalObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DirectStorageApproach.Infrastructure.Persistence.EntityConfigurations.TechnicalObjects;

internal sealed class TechnicalObjectEntityConfiguration
    : EntityConfiguration<TechnicalObject, Guid>
{
    public override void Configure(EntityTypeBuilder<TechnicalObject> builder)
    {
        base.Configure(builder);

        //Configuring Table-Per-Hierarchy
        builder
            .HasDiscriminator(technicalObject => technicalObject.Type)
            .HasValue<Equipment>(TechnicalObjectType.Equipment)
            .HasValue<FunctionalLocation>(TechnicalObjectType.FunctionalLocation);

        builder
            .Ignore(technicalObject => technicalObject.DomainEvents);

        builder.OwnsOne(technicalObject => technicalObject.Weight, subBuilder =>
        {
            subBuilder
                .Property(weight => weight.Value)
                .HasColumnName("Weight");

            subBuilder
                .Property(weight => weight.Unit)
                .HasColumnName("WeightUnit");
        });

        builder.OwnsOne(technicalObject => technicalObject.Acquisition, subBuilder =>
        {
            subBuilder
                .Property(acquisition => acquisition.Price)
                .HasColumnName("AcquisitionPrice");

            subBuilder
                .Property(acquisition => acquisition.Currency)
                .HasColumnName("AcquisitionCurrency");

            subBuilder
                .Property(acquisition => acquisition.Date)
                .HasColumnName("AcquisitionDate");
        });

        builder.OwnsOne(technicalObject => technicalObject.Manufacturer, subBuilder =>
        {
            subBuilder
                .Property(manufacturer => manufacturer.Name)
                .HasColumnName("ManufacturerName");

            subBuilder
                .Property(manufacturer => manufacturer.Country)
                .HasColumnName("ManufacturerCountry");

            subBuilder
                .Property(manufacturer => manufacturer.Model)
                .HasColumnName("ManufacturerModel");

            subBuilder
                .Property(manufacturer => manufacturer.PartNumber)
                .HasColumnName("ManufacturerPartNumber");

            subBuilder
                .Property(manufacturer => manufacturer.SerialNumber)
                .HasColumnName("ManufacturerSerialNumber");

            subBuilder
                .Property(manufacturer => manufacturer.ManufacturedAt)
                .HasColumnName("ManufacturedAt");
        });

        builder
            .HasOne(technicalObject => technicalObject.Parent)
            .WithMany(technicalObject => technicalObject.Children)
            .HasForeignKey(technicalObject => technicalObject.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(technicalObject => technicalObject.Children)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
