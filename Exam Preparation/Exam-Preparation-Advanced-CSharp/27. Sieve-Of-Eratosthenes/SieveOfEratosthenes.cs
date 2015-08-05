using System;
using System.Collections.Generic;

class TheSieveOfEratosthenes
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        HashSet<int> Primes = new HashSet<int>();

        // we will use this bool array, to store the information about postions between 1 and 10 000 000 
        // at which the numbers are prime or not-prime
        bool[] bigArr = new bool[N + 1];

        // we first set all positions in the bool array to true, all numbers will be considered prime unless proven otherwise
        for (int i = 0; i < bigArr.Length; i++)
        {
            bigArr[i] = true;
        }

        // this for loop supplies the base numbers for the calculation of the not-prime numbers
        for (int i = 2; i <= Math.Sqrt(bigArr.Length); i++)
        {
            // we will do the below calculations only with values of i whose positions in the array are not yet marked as false
            // or in other words, those values of i are note yet marked as not-prime
            if (bigArr[i])
            {
                // and here the not prime numbers get calculated: j = i * i (the square of i is definitely not prime), 
                // and et each step j increases with one more i; example: j = 2 * 2; and increases with 2 at each step
                // so we get: 2 * 2 + 2 = 3 * 2; +2 = 4 * 2 and we calculate all multiples of i (2) within the given range
                for (int j = i * i; j < bigArr.Length; j = j + i)
                {
                    bigArr[j] = false; // for all multiples of i; we mark their positions in the bool array as false, they are not prime
                }
            }
        }


        // if the position of a number into the bool array is still marked as true
        // we add the number to the Primes list, as this number is obviously proven to be prime
        for (int i = 2; i < bigArr.Length; i++)
        {
            if (bigArr[i])
            {
                Primes.Add(i);
            }
        }

        // preparing for print and printing
        string primes = string.Join(", ", Primes);
        Console.WriteLine(primes);
    }
}