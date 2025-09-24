namespace SfeirAPI.WebApi.Exceptions;

public class SfeirException(string? message, string? operationType) : Exception(message)
{
    public string? OperationType { get; private set; } = operationType;
}