# Find Missing Number in Array

A C# console application that demonstrates finding missing numbers in an array using **SOLID principles**.

## Overview

This project implements multiple algorithms to find missing numbers in a sequence, following all five SOLID principles for maintainable, testable, and extensible code. The current implementation uses the `SortAndSearchStrategy` with validation provided by the `ArrayValidator`.

## SOLID Principles Implementation

### 1. **Single Responsibility Principle (SRP)**
Each class has one reason to change:

- **`IMissingNumberFinder`** - Defines the contract for finding missing numbers
- **`SortAndSearchStrategy`** - Implements the sorting and searching algorithm
- **`ArrayValidator`** - Validates input arrays for correctness
- **`MissingNumberSolver`** - Coordinates the solving process with validation and strategy execution
- **`Program`** - Handles application entry point and testing

### 2. **Open/Closed Principle (OCP)**
The system is open for extension, closed for modification:

- **New algorithms** can be added by implementing `IMissingNumberFinder` without changing existing code
- **Different validation rules** can be added by extending or modifying `ArrayValidator`
- **Additional output formats** can be implemented without touching the algorithm

### 3. **Liskov Substitution Principle (LSP)**
Any implementation of `IMissingNumberFinder` can be substituted:

```csharp
// Any strategy can be used interchangeably
IMissingNumberFinder solver = new SortAndSearchStrategy(new ArrayValidator());
// Could be replaced with BooleanArrayStrategy, XORStrategy, etc.
```

### 4. **Interface Segregation Principle (ISP)**
Interfaces are focused and specific:

- **`IMissingNumberFinder`** defines a single method: `FindMissingNumber(int[] array)`
- **`IArrayValidator`** defines methods for validating input arrays
- Classes depend only on the methods they use, avoiding unnecessary dependencies

### 5. **Dependency Inversion Principle (DIP)**
High-level modules depend on abstractions:

```csharp
public class MissingNumberSolver
{
    private readonly IMissingNumberFinder _finder; // Depends on abstraction
    
    public MissingNumberSolver(IMissingNumberFinder finder) // Dependency injection
    {
        _finder = finder ?? throw new ArgumentNullException(nameof(finder));
    }
}
```

## Architecture Diagram

```
Program.cs
    ↓
MissingNumberSolver ← IMissingNumberFinder (Interface)
    ↓                        ↑
Validation/Display    SortAndSearchStrategy (Implementation)
    ↓
ArrayValidator
```

## Algorithm: Sort and Search Strategy

The implemented algorithm uses sorting and binary search to find missing numbers:

1. **Validation**: Ensure the array is not null, empty, or contains invalid values
2. **Sorting**: Sort the array to prepare for binary search
3. **Detection**: Use binary search to identify missing numbers

**Time Complexity**: O(n log n) (due to sorting)  
**Space Complexity**: O(1) (in-place sorting)

## Sample Output

```
=== Missing Number Finder (Sort and Search Strategy) ===

Test Case 1: [1,2,4,5,6] (Range 1-6)
✓ Missing number found: 3

Test Case 2: [2,3,4,5,6,7,8] (Range 1-8)  
✓ Missing number found: 1

Test Case 3: [1,2,3,4,6,7,8,9,10] (Range 1-10)
✓ Missing number found: 5

All 6 test cases passed!

=== Error Handling Demonstrations ===
✗ Null array: Cannot find missing number in null array
✗ Empty array: Array must contain at least one element
✗ Invalid range: All numbers must be positive
```

## Extending the Application

To add new algorithms while maintaining SOLID principles:

1. **Create new strategy** implementing `IMissingNumberFinder`
2. **Inject into MissingNumberSolver** via constructor
3. **No modifications needed** to existing code

Example:
```csharp
public class XORStrategy : IMissingNumberFinder
{
    public int FindMissingNumber(int[] array) 
    {
        // XOR implementation
    }
}

// Usage - just change the injected dependency
var solver = new MissingNumberSolver(new XORStrategy());
```