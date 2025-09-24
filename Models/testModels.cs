namespace FindMissingNumberInArray.Models;

public class TestCase
{
    public string Description { get; }
    public int[] Input { get; }
    public int Expected { get; }

    public TestCase(string description, int[] input, int expected)
    {
        Description = description;
        Input = input;
        Expected = expected;
    }
}

public class ErrorTestCase
{
    public string Description { get; }
    public int[] Input { get; }
    public string ExpectedExceptionType { get; }

    public ErrorTestCase(string description, int[] input, string expectedExceptionType)
    {
        Description = description;
        Input = input;
        ExpectedExceptionType = expectedExceptionType;
    }
}