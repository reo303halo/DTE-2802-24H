namespace Oppgave4;

internal static class Program
{
    private static void Swap(ref int i, ref int j)
    {
        (i, j) = (j, i);
    }

    private static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("You need to provide two numeric values via the command line.");
            return;
        }

        var x = int.Parse(args[0]);
        var y = int.Parse(args[1]);

        Console.WriteLine($"Initial values entered: x = {x}, y = {y}");
        Swap(ref x, ref y);
        Console.WriteLine($"Values after swap: x = {x}, y = {y}");
    }
}