using FindMissingNumberInArray.Interfaces;
using FindMissingNumberInArray.Strategies;
using FindMissingNumberInArray.Models;

namespace FindMissingNumberInArray;

class Program
{
    private const int MissingNumberIndicator = -1; // Define a constant for missing number indicator

    static void Main(string[] args)
    {
        Console.WriteLine("=== Missing Number Finder using sort and search method ===\n");

        // Initialize dependencies
        IArrayValidator arrayValidator = new ArrayValidator();
        IMissingNumberFinder strategy = new SortAndSearchStrategy(arrayValidator);
        var solver = new MissingNumberSolver(strategy);

        // Run tests and demonstrations
        RunStrategyTests(solver);
        Console.WriteLine();

        RunErrorStateTests(solver);
        Console.WriteLine();

        IMissingNumberFinder booleanArrayStrategy = new BooleanArrayStrategy(arrayValidator);
        solver.setStrategy(booleanArrayStrategy);

        Console.WriteLine("=== Missing Number Finder using boolean array strategy ===\n");
        // Run tests and demonstrations
        RunStrategyTests(solver);
        Console.WriteLine();

        RunErrorStateTests(solver);
        Console.WriteLine();
    }

    private static void RunStrategyTests(MissingNumberSolver solver)
    {
        int passed = 0;

        Console.WriteLine("--- Strategy Tests ---");

        // Externalize test cases for better organization
        var testCases = GetTestCases();

        foreach (var testCase in testCases)
        {
            try
            {
                Console.Write($"{testCase.Description}: ");
                int result = solver.Run(testCase.Input);

                if (result == testCase.Expected)
                {
                    passed++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        Console.WriteLine($"Results: {passed}/{testCases.Length} tests passed");
    }

    private static void RunErrorStateTests(MissingNumberSolver solver)
    {
        Console.WriteLine("--- Error Handling Demo ---");

        var errorTestCases = GetErrorTestCases();

        foreach (var testCase in errorTestCases)
        {
            Console.Write($"{testCase.Description}: ");
            try
            {
                int result = solver.Run(testCase.Input);
                Console.WriteLine($"Unexpected success: {result} \u2717");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == testCase.ExpectedExceptionType)
                {
                    Console.WriteLine($"{ex.GetType().Name} \u2713");
                }
                else
                {
                    Console.WriteLine($"{ex.GetType().Name} \u2717 (expected {testCase.ExpectedExceptionType})");
                }
            }
        }
        Console.WriteLine();
    }

    private static TestCase[] GetTestCases()
    {
        return
        [
            new TestCase("Missing Number", new int[] { 3, 0, 1 }, 2),
            new TestCase("Complete Array", new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1, 8 }, MissingNumberIndicator),
            new TestCase("Missing Zero", new int[] { 1, 2, 3 }, 0),
            new TestCase("Single Element", new int[] { 1 }, 0),
            new TestCase("Missing Number Long Array", new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8),
        ];
    }

    private static ErrorTestCase[] GetErrorTestCases()
    {
        return
        [
            new ErrorTestCase("Null Array", null!, "ArgumentException"),
            new ErrorTestCase("Empty Array", new int[0], "ArgumentException"),
            new ErrorTestCase("Negative Numbers", new int[] { -1, 0, 1 }, "ArgumentException")
        ];
    }
}
