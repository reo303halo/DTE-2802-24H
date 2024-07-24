namespace TaskC;

public static class TemperatureConverter
{
    private static double FromCelsiusToFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }

    private static double FromFahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public static double ConvertTemp(string command)
    {
        var parts = command.Split(' ');
        if (parts.Length != 3)
        {
            throw new ArgumentException("Invalid input format. Please use 'convert [temperature] [C/F]'");
        }

        var temperature = double.Parse(parts[1]);
        var unit = parts[2].ToUpper();
    
        return unit switch
        {
            "C" => FromCelsiusToFahrenheit(temperature),
            "F" => FromFahrenheitToCelsius(temperature),
            _ => throw new ArgumentException("Invalid unit. Please use 'C' or 'F'")
        };
    }
}