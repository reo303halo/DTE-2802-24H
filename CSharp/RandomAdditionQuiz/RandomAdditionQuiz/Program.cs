// See https://aka.ms/new-console-template for more information

Random random = new Random();
string? continueLoop = "y";

while (continueLoop == "y")
{
    int number1 = random.Next(0, 11);
    int number2 = random.Next(0, 51);
    
    Console.Write($"What is {number1} + {number2}? ");
    int userAnswer = int.Parse(Console.ReadLine());

    Console.WriteLine(userAnswer == number1 + number2 ? "Correct!" : "Wrong answer!");
    
    Console.Write("Press Y to start again, or any other button to Quit: ");
    continueLoop = Console.ReadLine()?.ToLower();
}





