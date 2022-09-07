namespace Compiler.Shared
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
    }
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}