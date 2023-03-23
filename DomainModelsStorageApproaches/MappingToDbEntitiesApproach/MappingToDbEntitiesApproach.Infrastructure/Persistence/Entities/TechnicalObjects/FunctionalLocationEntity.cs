namespace MappingToDbEntitiesApproach.Infrastructure.Persistence.Entities.TechnicalObjects;

internal sealed class FunctionalLocationEntity : TechnicalObjectEntity
{
    public bool IsEquipmentInstallAllowed { get; set; }
    public bool IsSingleEquipmentInstalled { get; set; }
}
