namespace TaskA;

internal static class Program
{
    private static double CalculateArea(double sideA, double sideB)
    {
        return sideA * sideB;
    }

    private static double CalculatePerimeter(double sideA, double sideB)
    {
        return sideA * 2 + sideB * 2;
    }

    private static void Main()
    {
        Console.WriteLine("Enter side A: ");
        var a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter side B: ");
        var b = Convert.ToDouble(Console.ReadLine());

        var area = CalculateArea(a, b); // Alternative: var area = a * b;
        Console.WriteLine($"The area is: {area}");

        var perimeter = CalculatePerimeter(a, b); // Alternative: var perimeter = a * 2 + b * 2;
        Console.WriteLine($"The perimeter is: {perimeter}");
    }
}