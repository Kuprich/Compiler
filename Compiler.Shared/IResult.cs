namespace Compiler.Shared
{
    public interface IResult
    {
        bool IsSuccess { get; }
    }
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}