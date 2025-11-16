namespace Athr.Application.Exceptions;

public sealed record ApplicationError(
    string Key,
    string ErrorMessage);
