namespace TaskCAlternative;

internal static class TemperatureConverter
{
    public static double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }

    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: dotnet run <temperature> <scale>");
            Console.WriteLine("Example: dotnet run 37 C");
            return;
        }

        try
        {
            var temperature = Convert.ToDouble(args[0]);
            var scale = args[1].ToUpper();

            switch (scale)
            {
                case "C":
                {
                    var convertedTemp = TemperatureConverter.CelsiusToFahrenheit(temperature);
                    Console.WriteLine($"{temperature}°C is {convertedTemp:F2}°F");
                    break;
                }
                case "F":
                {
                    var convertedTemp = TemperatureConverter.FahrenheitToCelsius(temperature);
                    Console.WriteLine($"{temperature}°F is {convertedTemp:F2}°C");
                    break;
                }
                default:
                    Console.WriteLine("Scale must be 'C' for Celsius or 'F' for Fahrenheit.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid temperature value. Please enter a number.");
        }
    }
}
