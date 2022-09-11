namespace Compiler.Shared.Wrapper;


public class Result<T>
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }

    public T? Data { get; set; } = default!;

    public static Result<T> Succeess(T? value, string message = "") =>
        new() { Data = value, IsSuccess = true, Message = message };

    public static Task<Result<T>> SucceessAsync(T? data, string message = "")
        => Task.FromResult(Succeess(data, message));

    public static Result<T> Fail(string message = "") =>
        new() { IsSuccess = false, Message = message };

    public static Task<Result<T>> FailAsync(string message = "")
       => Task.FromResult(Fail(message));

}
