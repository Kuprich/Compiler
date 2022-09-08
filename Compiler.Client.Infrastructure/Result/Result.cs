using ErrorOr;

namespace Compiler.Client.Infrastructure.Result;

public class Result<T>
{
    public T Value { get; set; } = default!;

    public ResponseError ResponseError { get; set; }
    public bool Succeeded { get; set; }
    public static Result<T> Succeess(T value)
    {
        return new Result<T> { Value = value, Succeeded = true };
    }
    public static Result<T> Fail(ResponseError error)
    {
        return new Result<T> { ResponseError = error, Succeeded = false };
    }
}

public struct ResponseError
{
    public ResponseError(string code, string description, int numericType)
    {
        Code = code;
        Description = description;
        NumericType = numericType;
    }

    //
    // Summary:
    //     Gets the unique error code.
    public string Code { get; }

    //
    // Summary:
    //     Gets the error description.
    public string Description { get; }

    //
    // Summary:
    //     Gets the numeric value of the type.
    public int NumericType { get; }
}
