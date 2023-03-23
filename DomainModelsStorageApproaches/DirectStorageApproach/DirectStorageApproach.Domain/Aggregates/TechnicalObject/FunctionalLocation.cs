using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectStorageApproach.Domain.Aggregates.TechnicalObject;

public sealed class FunctionalLocation : TechnicalObject
{
    public bool IsEquipmentInstallAllowed { get; private set; }
    public bool IsSingleEquipmentInstalled { get; private set; }

    public FunctionalLocation(
        Guid id,
        string name,
        string code,
        char category) : base(id, name, code, category)
    {
        Type = TechnicalObjectType.FunctionalLocation;
    }

    public void AddChildren(IEnumerable<TechnicalObject> technicalObjets)
    {
        if (technicalObjets is null || technicalObjets.Any() is false)
            return;

        _children.AddRange(technicalObjets);
    }
}
