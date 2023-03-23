using System.Collections.Generic;

namespace DirectStorageApproach.Domain.Results;

public class Result<TValue> : Result
{
    public TValue Value { get; private set; }

    protected internal Result(TValue value) : base()
    {
        Value = value;
    }

    protected internal Result(Error error) : base(error) { }
    protected internal Result(List<Error> errors) : base(errors) { }

    public static Result<TValue> Ok(TValue value) => new(value);

    public static implicit operator Result<TValue>(TValue value) => new(value);
    public static implicit operator Result<TValue>(List<Error> errors) => new(errors);
    public static implicit operator Result<TValue>(Error error) => new(error);
}
