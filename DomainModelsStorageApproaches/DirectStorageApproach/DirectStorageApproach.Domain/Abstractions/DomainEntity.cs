namespace DirectStorageApproach.Domain.Abstractions;

public abstract class DomainEntity<TIdentifier>
{
    public TIdentifier Id { get; }

    public DomainEntity(TIdentifier id)
    {
        Id = id;
    }
}
