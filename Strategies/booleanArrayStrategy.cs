using FindMissingNumberInArray.Interfaces;

namespace FindMissingNumberInArray.Strategies;

class BooleanArrayStrategy : IMissingNumberFinder
{

    private IArrayValidator _arrayCheck;

    public BooleanArrayStrategy(IArrayValidator arrayCheck)
    {
        _arrayCheck = arrayCheck;
    }

    public int FindMissingNumber(int[] array)
    {
        if (!_arrayCheck.ValidateInputs(array))
        {
            throw new ArgumentException("Invalid input");
        }

        int maxValue = array.Max();
        int arrayLength = array.Length;

        // get length and if they are the same as the max number + 1 then all numbers are present.
        // Numbers are in the range 0 to n and there are no repetitions in the array.
        if (arrayLength == maxValue + 1)
        {
            return -1; // All numbers are present
        }


        // otherwise, assume that the max length is max number + 1 and find the missing number from 0 - (max number).
        bool[] present = new bool[maxValue + 1];

        // Mark the numbers present in the array
        foreach (var num in array)
        {
            if (num < maxValue + 1)
            {
                present[num] = true;
            }
        }

        // Find the first number that is not present
        for (int i = 0; i < arrayLength; i++)
        {
            if (!present[i])
            {
                return i;
            }
        }

        return -1; // This should never be reached if input is valid
    }
}