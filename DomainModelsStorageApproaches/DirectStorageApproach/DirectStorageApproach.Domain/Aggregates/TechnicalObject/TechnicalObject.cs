using DirectStorageApproach.Domain.Abstractions;
using DirectStorageApproach.Domain.Aggregates.TechnicalObject.ValueObjects;
using System;
using System.Collections.Generic;

namespace DirectStorageApproach.Domain.Aggregates.TechnicalObject;

public abstract class TechnicalObject : AggregateRoot
{
    protected readonly List<TechnicalObject> _children;

    public string Name { get; private set; }
    public string Code { get; private set; }
    public string Description { get; private set; }
    public char Category { get; private set; }
    public Guid CreatedBy { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public Weight Weight { get; private set; }
    public Acquisition Acquisition { get; private set; }
    public Manufacturer Manufacturer { get; private set; }

    public TechnicalObjectType Type { get; protected set; }
    public Guid ParentId { get; private set; }
    public TechnicalObject Parent { get; private set; }
    public IReadOnlyCollection<TechnicalObject> Children => _children;

    protected TechnicalObject(
        Guid id,
        string name,
        string code,
        char category) : base(id)
    {
        Name = name;
        Category = category;
        Code = code;

        _children = new();
    }
}
