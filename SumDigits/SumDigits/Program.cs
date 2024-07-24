namespace SumDigits;

internal abstract class Program
{
    private static int SumDigits(int n)
    {
        if (n == 0)
            return n;
        
        return n % 10 + SumDigits(n / 10);
    }

    private static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        Console.WriteLine($"The sum of {number} is: {SumDigits(number)}");
    }
}
