namespace Compiler.Client.Infrastructure;

public class Routes
{
    public class CompilerEndpoints
    {
        public const string RunAllTests = "api/Compiler/RunAllTests";
    }

    public class PracticeEndpoints
    {
        public const string GetAllPractices = "api/Practice/GetAllPractices";
        public static string GetPracticeCard(Guid id) => $"api/Practice/GetPracticeCard?{id}";
    }
}
