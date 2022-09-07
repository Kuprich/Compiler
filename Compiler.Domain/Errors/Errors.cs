using ErrorOr;

namespace Compiler.Domain.Errors;

public static class Errors
{
    public static class PracticeCard
    {
        public static Error NotFound => Error.NotFound(
            code: "PracticeCard.NotFound",
            description: "Practice cards not found");
    }
}
