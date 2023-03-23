namespace MappingToDbEntitiesApproach.Domain.Results;

internal static class DomainErrors
{
    internal static class Statuses
    {
        public static Error UnableToChangeStatus(string fromStatusName, string toStatusName)
        {
            return new($"Unable to change status from '{fromStatusName}' to '{toStatusName}'");
        }
    }
}
