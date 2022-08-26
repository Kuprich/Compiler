namespace Compiler.Application.Compiler.RunTests;

public class RunTestsQuery
{
    public RunTestsQuery(string mainClassText, string testClassText)
    {
        MainClassText = mainClassText;
        TestClassText = testClassText;
    }

    string MainClassText { get; }
    string TestClassText { get; }
}
