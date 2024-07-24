namespace TaskB;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Enter your weight in kg: ");
        var inputWeight = Console.ReadLine();
        Console.WriteLine("Enter your height in meters: ");
        var inputHeight = Console.ReadLine();
        
        var weight = Convert.ToDouble(inputWeight);
        var height = Convert.ToDouble(inputHeight);

        var bmi = weight / (height * height);

        Console.WriteLine($"Your BMI is: {bmi}");

        var message = bmi switch
        {
            < 18.5 => "Underweight",
            >= 18.5 and <= 24.9 => "Normal",
            > 24.9 and <= 29.9 => "Overweight",
            _ => "Obesity"
        };
        Console.WriteLine($"Your BMI is: {bmi:F2}");
        Console.WriteLine(message);
    }
}