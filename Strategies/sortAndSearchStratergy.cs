using FindMissingNumberInArray.Interfaces;

namespace FindMissingNumberInArray.Strategies;

class SortAndSearchStrategy : IMissingNumberFinder
{
    private IArrayValidator _arrayCheck;

    public SortAndSearchStrategy(IArrayValidator arrayCheck)
    {
        _arrayCheck = arrayCheck;
    }
    public int FindMissingNumber(int[] array)
    {
        if (!_arrayCheck.ValidateInputs(array))
        {
            throw new ArgumentException("Invalid input");
        }

        var index = 0;
        Array.Sort(array);
        foreach (var num in array)
        {
            if (num != index)
                return index;  // Found the missing number
            index++;
        }

        return -1; // All numbers are present
    }
}