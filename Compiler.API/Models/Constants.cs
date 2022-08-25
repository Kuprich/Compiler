namespace Compiler.API.Models;

public static class  Constants
{
    public const string MainClassText = @"
        using System;

        public class NumberGenerator
        {
            public int GenerateNum()
            {
                return 1;
            }
        }";

    public const string TestClassText = @"
        using System;
        using NUnit.Framework;
        
        [TestFixture]
        public class Tests
        {
            [SetUp]
            public void Setup() { }

            [Test]
            public void Test1()
            {
                NumberGenerator generator = new ();
                Assert.IsTrue(1 == generator.GenerateNum());
            }

            [Test]
            public void Test2()
            {
                NumberGenerator generator = new ();
                Assert.IsTrue(2 == generator.GenerateNum());
            }
        }";

    public const string TestClassName = "Tests";
}
