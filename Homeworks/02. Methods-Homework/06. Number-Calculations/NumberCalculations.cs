/* Problem 6.	Number Calculations
Write methods to calculate the minimum, maximum, average, sum and product of a given set of numbers. 
 * Overload the methods to work with numbers of type int and double.
Note: Do not use LINQ.
 */

using System;
using System.Linq;

class NumberCalculations
{
    static void Main()
    {
        char[] charSeparators = new char[] { ' ' };

        // int input and calculations
        Console.WriteLine("Please, enter a couple of type double numbers, all in one line, separated by a space: ");
        double[] doubles = Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

        Console.WriteLine("0utput:\nMin: {0}, Max: {1}, Sum: {2}, Average: {3}, Product: {4}", 
            GetMin(doubles), GetMax(doubles), GetSum(doubles), GetAverage(doubles), GetProduct(doubles));

        // double input and calculations
        Console.WriteLine("\nPlease, enter a couple of type decimal numbers, all in one line, separated by a space: ");
        decimal[] decimals = Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

        Console.WriteLine("0utput:\nMin: {0}, Max: {1}, Sum: {2}, Average: {3}, Product: {4}",
            GetMin(decimals), GetMax(decimals), GetSum(decimals), GetAverage(decimals), GetProduct(decimals));
    }
    // Min
    static decimal GetMin(decimal[] numbers)
    {
        decimal min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min) min = numbers[i];
        }
        return min;
    }
    static double GetMin(double[] numbers)
    {
        double min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min) min = numbers[i];
        }
        return min;
    }

    // Max
    static decimal GetMax(decimal[] numbers)
    {
        decimal max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max) max = numbers[i];
        }
        return max;
    }
    static double GetMax(double[] numbers)
    {
        double max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max) max = numbers[i];
        }
        return max;
    }

    // Sum
    static decimal GetSum(decimal[] numbers)
    {
        decimal sum = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static double GetSum(double[] numbers)
    {
        double sum = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    // Average
    static decimal GetAverage(decimal[] numbers)
    {
        return GetSum(numbers) / numbers.Length;
    }
    static double GetAverage(double[] numbers)
    {
        return GetSum(numbers) / numbers.Length;
    }

    // Product
    static decimal GetProduct(decimal[] numbers)
    {
        decimal product = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }
    static double GetProduct(double[] numbers)
    {
        double product = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }
}

