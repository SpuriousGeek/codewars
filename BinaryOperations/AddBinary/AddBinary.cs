namespace BinaryOperations;

/// <summary>
///     Provides multiple implementations for converting the sum of two integers to binary representation.
///     This class demonstrates different approaches: built-in conversion, iterative algorithm, and recursive algorithm.
/// </summary>
public static class AddBinary
{
    /// <summary>
    ///     Converts the sum of two integers to binary using .NET's built-in Convert.ToString method.
    ///     This is the most efficient and concise approach, leveraging the framework's optimized implementation.
    /// </summary>
    /// <param name="a">The first integer to add</param>
    /// <param name="b">The second integer to add</param>
    /// <returns>A string representing the binary form of (a + b)</returns>
    /// <example>
    /// <code>
    /// string result = AddBinary.Solution1(5, 3); // Returns "1000" (decimal 8 in binary)
    /// </code>
    /// </example>
    public static string Solution1(int a, int b) => Convert.ToString(a + b, 2);

    /// <summary>
    ///     Converts the sum of two integers to binary using an iterative approach.
    ///     This method manually implements the binary conversion algorithm by repeatedly dividing by 2
    /// and collecting remainders, building the binary string from right to left.
    /// </summary>
    /// <param name="a">The first integer to add</param>
    /// <param name="b">The second integer to add</param>
    /// <returns>A string representing the binary form of (a + b)</returns>
    /// <remarks>
    /// The algorithm works by:
    /// 1. Computing the sum of the two input integers
    /// 2. Repeatedly dividing by 2 and prepending the remainder (0 or 1) to build the binary string
    /// 3. Continuing until the quotient becomes 0
    /// Note: This implementation has a edge case - it returns empty string for sum = 0
    /// </remarks>
    /// <example>
    /// <code>
    /// string result = AddBinary.Solution2(7, 1); // Returns "1000" (decimal 8 in binary)
    /// </code>
    /// </example>
    public static string Solution2(int a, int b)
    {
        var sum = a + b;
        string binaryRepresentation = "";

        // Handle the edge case where sum is 0
        if (sum == 0)
            return "0";

        // Convert to binary by repeatedly dividing by 2
        while (sum > 0)
        {
            // Prepend the remainder (0 or 1) to build binary string from right to left
            binaryRepresentation = (sum % 2) + binaryRepresentation;
            sum /= 2; // Integer division effectively removes the least significant bit
        }
        return binaryRepresentation;
    }

    /// <summary>
    ///     Converts the sum of two integers to binary using a recursive approach.
    ///     This method demonstrates how binary conversion can be implemented recursively,
    /// where each recursive call handles one bit position.
    /// </summary>
    /// <param name="a">The first integer to add</param>
    /// <param name="b">The second integer to add</param>
    /// <returns>A string representing the binary form of (a + b)</returns>
    /// <remarks>
    /// This implementation uses a nested local function that recursively builds the binary representation.
    /// The recursion works by:
    /// 1. Base case: when number becomes 0, return empty string
    /// 2. Recursive case: call itself with number/2 and append the current bit (number%2)
    /// Note: This implementation also has the same edge case as Solution2 - returns empty string for sum = 0
    /// </remarks>
    /// <example>
    /// <code>
    /// string result = AddBinary.Solution3(4, 4); // Returns "1000" (decimal 8 in binary)
    /// </code>
    /// </example>
    public static string Solution3(int a, int b)
    {
        var sum = a + b;

        /// <summary>
        ///     Local recursive function that converts a positive integer to its binary representation.
        ///     The recursion builds the binary string from left to right by processing higher-order bits first.
        /// </summary>
        /// <param name="number">The positive integer to convert to binary</param>
        /// <returns>Binary string representation of the number</returns>
        static string ConvertToBinary(int number)
        {
            // Base case: when we've processed all bits
            if (number == 0)
                return "";

            // Recursive case: process higher-order bits first, then append current bit
            return ConvertToBinary(number / 2) + (number % 2).ToString();
        }

        // Handle the edge case where sum is 0
        if (sum == 0)
            return "0";

        return ConvertToBinary(sum);
    }
}