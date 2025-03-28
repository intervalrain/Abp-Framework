using Shouldly;

namespace Volo.ExtensionMethods.Tests;

public class StringExtensions_Tests
{
    [Fact]
    public void EnsureEndsWith_Test()
    {
        "Test".EnsureEndsWith('!').ShouldBe("Test!");
        "Test!".EnsureEndsWith('!').ShouldBe("Test!");
        @"C:\test\folderName".EnsureEndsWith('\\').ShouldBe(@"C:\test\folderName\");
        @"C:\test\folderName\".EnsureEndsWith('\\').ShouldBe(@"C:\test\folderName\");

        "TurkeY".EnsureEndsWith('y').ShouldBe("TurkeYy");
    }

    [Fact]
    public void EnsureStartsWith_Test()
    {
        "Test".EnsureStartsWith('~').ShouldBe("~Test");
        "~Test".EnsureStartsWith('~').ShouldBe("~Test");

        "Turkey".EnsureStartsWith('t').ShouldBe("tTurkey");
    }

    [Fact]
    public void ToPascalCase_Test()
    {
        (null as string).ToPascalCase().ShouldBeNull();
        "helloWorld".ToPascalCase().ShouldBe("HelloWorld");
        "istanbul".ToPascalCase().ShouldBe("Istanbul");
    }

    [Fact]
    public void ToCamelCase_Test()
    {
        (null as string).ToCamelCase().ShouldBeNull();
        "HelloWorld".ToCamelCase().ShouldBe("helloWorld");
        "Istanbul".ToCamelCase().ShouldBe("istanbul");
    }

    [Fact]
    public void ToSentenceCase_Test()
    {
        (null as string).ToSentenceCase().ShouldBeNull();
        "HelloWorld".ToSentenceCase().ShouldBe("Hello world");
        "HelloIsparta".ToSentenceCase().ShouldBe("Hello isparta");
    }

    [Fact]
    public void Right_Test()
    {
        const string str = "This is a test string";
        str.Right(3).ShouldBe("ing");
        str.Right(0).ShouldBe("");
        str.Right(str.Length).ShouldBe(str);
    }

    [Fact]
    public void Left_Test()
    {
        const string str = "This is a test string";
        str.Left(3).ShouldBe("Thi");
        str.Left(0).ShouldBe("");
        str.Left(str.Length).ShouldBe(str);
    }

    [Fact]
    public void NormalizeLineEndings_Test()
    {
        const string str = "This\r is a\r test \n string";
        var normalized = str.NormalizeLineEndings();
        var lines = normalized.SplitToLines();
        lines.Length.ShouldBe(4);
    }

    [Fact]
    public void NthIndexOf_Test()
    {
        const string str = "This is a test string";

        str.NthIndexOf('i', 0).ShouldBe(-1);
        str.NthIndexOf('i', 1).ShouldBe(2);
        str.NthIndexOf('i', 2).ShouldBe(5);
        str.NthIndexOf('i', 3).ShouldBe(18);
        str.NthIndexOf('i', 4).ShouldBe(-1);
    }

    [Fact]
    public void Truncate_Test()
    {
        const string str = "This is a test string";
        const string? nullValue = null;

        str.Truncate(7).ShouldBe("This is");
        str.Truncate(0).ShouldBe("");
        str.Truncate(100).ShouldBe(str);

        nullValue.Truncate(5).ShouldBeNull();
    }

    [Fact]
    public void TruncateWithPostfix_Test()
    {
        const string str = "This is a test string";
        const string? nullValue = null;

        str.TruncateWithPostfix(3).ShouldBe("...");
        str.TruncateWithPostfix(12).ShouldBe("This is a...");
        str.TruncateWithPostfix(0).ShouldBe("");
        str.TruncateWithPostfix(100).ShouldBe(str);

        nullValue.Truncate(5).ShouldBeNull();

        str.TruncateWithPostfix(3, "~").ShouldBe("Th~");
        str.TruncateWithPostfix(12, "~").ShouldBe("This is a t~");
        str.TruncateWithPostfix(0, "~").ShouldBe("");
        str.TruncateWithPostfix(100, "~").ShouldBe(str);

        nullValue.TruncateWithPostfix(5, "~").ShouldBeNull();
    }

    [Fact]
    public void RemovePostfix_Tests()
    {
        (null as string)?.RemovePostfix("Test").ShouldBeNull();

        "MyTestAppService".RemovePostfix("AppService").ShouldBe("MyTest");
        "MyTestAppService".RemovePostfix("Service").ShouldBe("MyTestApp");
        "MyTestAppService".RemovePostfix("AppService", "Service").ShouldBe("MyTest");
        "MyTestAppService".RemovePostfix("Service", "AppService").ShouldBe("MyTestApp");
        "MyTestAppService".RemovePostfix("Unmatched").ShouldBe("MyTestAppService");
    }

    [Fact]
    public void RemovePrefix_Tests()
    {
        "Home.Index".RemovePrefix("NotMatchedPrefix").ShouldBe("Home.Index");
        "Home.About".RemovePrefix("Home.").ShouldBe("About");
    }

    [Fact]
    public void ToEnum_Test()
    {
        "MyValue1".ToEnum<MyEnum>().ShouldBe(MyEnum.MyValue1);
        "MyValue2".ToEnum<MyEnum>().ShouldBe(MyEnum.MyValue2);
    }

    private enum MyEnum
    {
        MyValue1,
        MyValue2
    }
    
}