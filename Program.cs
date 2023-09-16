using System;
using System.IO;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int low;
        int high;

        Console.WriteLine("Enter low number:");
        low = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter high number:");
        high = int.Parse(Console.ReadLine());

        while (high <= low)
        {
            Console.WriteLine("Enter a high number which is greater than the low number:");
            high = int.Parse(Console.ReadLine());
        }

        while (low <= 0)
        {
            Console.WriteLine("Enter a positive low number:");
            low = int.Parse(Console.ReadLine());
        }

        int difference = high - low;
        Console.WriteLine($"The difference between low and high is {difference}");

        int[] numbers = Enumerable.Range(low, high - low + 1).ToArray();

        using (StreamWriter writer = new StreamWriter("numbers.txt"))
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                writer.WriteLine(numbers[i]);
            }
        }

        Console.WriteLine("Numbers are written to numbers.txt.");

       
        foreach (int n in numbers)
        {
            if (IsPrime(n))
            {
                Console.WriteLine($"{n} is a prime number.");
            }
        }
    }

    static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;
        for (int denominator = 2; denominator * denominator <= n; denominator++)
        {
            if (n % denominator == 0)
                return false;
        }
        return true;
    }
}