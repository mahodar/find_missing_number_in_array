using FindMissingNumberInArray.Interfaces;

namespace FindMissingNumberInArray;

class MissingNumberSolver
{
    private readonly IMissingNumberFinder _numberFinder;

    public MissingNumberSolver(IMissingNumberFinder numberFinder)
    {
        _numberFinder = numberFinder ?? throw new ArgumentNullException(nameof(numberFinder));
    }

    public int Run(int[] array)
    {
        try
        {
            var missingNumber = _numberFinder.FindMissingNumber(array);
            DisplayResult(array, missingNumber);

            return missingNumber;
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
            throw;
        }
    }

    private static void DisplayResult(int[] array, int missingNumber)
    {
        Console.WriteLine($"Array: [{string.Join(", ", array)}]");
        Console.WriteLine($"Missing number: {(missingNumber >= 0 ? missingNumber.ToString() : "None")}");
        Console.WriteLine();
    }

    private static void DisplayError(string errorMessage)
    {
        Console.WriteLine($"Error: {errorMessage}");
        Console.WriteLine();
    }
}