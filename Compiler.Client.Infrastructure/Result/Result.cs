using ErrorOr;

namespace Compiler.Client.Infrastructure.Result;

public class Result<T>
{
    public T Value { get; set; } = default!;

    public ResultError? ResultError { get; set; }
    public bool Succeeded { get; set; }
    public static Result<T> Succeess(T value)
    {
        return new Result<T> { Value = value, Succeeded = true };
    }
    public static Result<T> Fail(ResultError error)
    {
        return new Result<T> { ResultError = error, Succeeded = false };
    }
}
