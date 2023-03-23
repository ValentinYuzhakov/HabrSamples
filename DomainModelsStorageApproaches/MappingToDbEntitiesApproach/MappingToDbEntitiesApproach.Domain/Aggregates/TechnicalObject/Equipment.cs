using System;
using System.Collections.Generic;
using System.Linq;

namespace MappingToDbEntitiesApproach.Domain.Aggregates.TechnicalObject;

public sealed class Equipment : TechnicalObject
{
    public Equipment(
        Guid id,
        string name,
        string code,
        char category) : base(id, name, code, category) { }

    public void AddChildren(IEnumerable<Equipment> equipments)
    {
        if (equipments is null || equipments.Any() is false)
            return;

        _children.AddRange(equipments);
    }
}
