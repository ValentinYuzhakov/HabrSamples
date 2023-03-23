namespace DirectStorageApproach.Domain.Results;

public sealed class Error
{
    public string Message { get; }

    public Error(string message)
    {
        Message = message;
    }
}
