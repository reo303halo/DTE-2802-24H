namespace TaskC;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello Temperature Converter!");
        Console.WriteLine("Enter command like following 'convert [temperature] [C/F]': ");

        var userInput = Console.ReadLine();

        if (userInput == null) return;
        var result = TemperatureConverter.ConvertTemp(userInput);

        Console.WriteLine($"The converted value is: {result}");
    }
}

