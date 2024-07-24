namespace Oppgave5;

internal class BinTall
{
    private readonly int _number;
    public string IntString => Convert.ToString(_number);
    public string BinString => Convert.ToString(_number, 2);

    public BinTall(int intNumber)
    {
        _number = intNumber;
    }

    public BinTall(string binNumber)
    {
        if (IsValidBinary(binNumber))
        {
            _number = Convert.ToInt32(binNumber, 2);
        }
        else
        {
            throw new ArgumentException("Invalid binary string.", nameof(binNumber));
        }
    }

    private static bool IsValidBinary(string binNumber)
    {
        return binNumber.All(c => c is '0' or '1');
    }
    
    public static BinTall operator +(BinTall a, BinTall b)
    {
        var sum = a._number + b._number;
        return new BinTall(sum);
    }

    public static BinTall operator +(BinTall a, int b)
    {
        var sum = a._number + b;
        return new BinTall(sum);
    }
    
    public static BinTall operator +(int a, BinTall b)
    {
        var sum = a + b._number;
        return new BinTall(sum);
    }
    
    public static BinTall operator -(BinTall a, BinTall b)
    {
        var sum = a._number - b._number;
        return new BinTall(sum);
    }
    
    public static BinTall operator *(BinTall a, BinTall b)
    {
        var product = a._number * b._number;
        return new BinTall(product);
    }
    
    public void PrintInt()
    {
        Console.WriteLine(_number);
    }

    public void PrintBin()
    {
        var bin = Convert.ToString(_number, 2);
        Console.WriteLine(bin);
    }
}

internal static class Program
{
    private static void Main()
    {
        var binObject1 = new BinTall(7);
        
        Console.WriteLine("Printing binObject1 as both binary and int: ");
        binObject1.PrintBin();
        binObject1.PrintInt();

        var binObject2 = new BinTall("110");
        
        Console.WriteLine("\nNow we do the same with binObject2: ");
        binObject2.PrintBin();
        binObject2.PrintInt();

        Console.WriteLine("\nAnd then we try the operators: ");
        var sum1 = binObject1 + binObject2;
        Console.WriteLine($"binObject1 + binObject2 = \nint: {sum1.IntString}\nbin: {sum1.BinString}");
        
        Console.WriteLine($"\n{binObject1}1 + 6 = {(binObject1 + 6).IntString} (int)");
        Console.WriteLine($"\n8 + {binObject2}2 = {(8 + binObject2).BinString} (bin)");
        
        Console.WriteLine($"\n{binObject1.BinString} - {binObject2.BinString} = {(binObject1 - binObject2).BinString}");
        Console.WriteLine($"\n{binObject1.IntString} * {binObject2.IntString} = {(binObject1 * binObject2).IntString}");
    }
}