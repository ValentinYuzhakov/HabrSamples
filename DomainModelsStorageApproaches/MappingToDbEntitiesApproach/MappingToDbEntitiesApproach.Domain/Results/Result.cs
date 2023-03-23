using System.Collections.Generic;
using System.Linq;

namespace MappingToDbEntitiesApproach.Domain.Results;

public class Result
{
    private readonly List<Error> _errors = new();

    public bool IsSucceeded { get; }
    public bool HasErrors { get => _errors.Any(); }
    public IReadOnlyCollection<Error> Errors => _errors;

    protected Result() { IsSucceeded = true; }

    protected Result(Error error)
    {
        IsSucceeded = false;
        _errors.Add(error);
    }

    protected Result(List<Error> errors)
    {
        IsSucceeded = false;
        _errors.AddRange(errors);
    }

    public static Result Ok() => new();

    public static implicit operator Result(Error error) => new(error);
    public static implicit operator Result(List<Error> errors) => new(errors);
}