using MappingToDbEntitiesApproach.Domain.Aggregates.TechnicalObject.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.TechnicalObjects;

internal abstract class TechnicalObjectEntity : DbEntity<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public char Category { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Weight Weight { get; set; }
    public Acquisition Acquisition { get; set; }
    public Manufacturer Manufacturer { get; set; }
    public bool HasChildren { get; set; }
    public TechnicalObjectEntityType Type { get; set; }

    public LTree Path { get; set; }
    public Guid? ParentId { get; set; }
    public TechnicalObjectEntity Parent { get; set; }
    public ICollection<TechnicalObjectEntity> Children { get; set; }
    public ICollection<NotificationTechnicalObjectLink> Notifications { get; set; }
}
