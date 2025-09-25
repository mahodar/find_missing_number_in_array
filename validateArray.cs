using System;

using FindMissingNumberInArray.Interfaces;

namespace FindMissingNumberInArray;

class ArrayValidator : IArrayValidator
{
    // Validates if the array is not null and has at least one element
    private bool IsValid(int[] array)
    {
        return array != null && array.Length > 0;
    }

    private bool ContainsNegativeNumbers(int[] array)
    {
        if (!IsValid(array))
            return false;

        return array.Any(num => num < 0);
    }

    // Validates if the array contains only unique elements
    private bool HasUniqueElements(int[] array)
    {
        if (!IsValid(array))
            return false;

        var set = new HashSet<int>();
        foreach (var num in array)
        {
            if (!set.Add(num))
                return false;
        }
        return true;
    }

    public bool ValidateInputs(int[] array)
    {
        return IsValid(array) && !ContainsNegativeNumbers(array) && HasUniqueElements(array);
    }
}
