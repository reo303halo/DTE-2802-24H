
string? firstname = "";
while (string.IsNullOrEmpty(firstname))
{
    Console.WriteLine("Please enter firstname: ");
    firstname = Console.ReadLine();
}

string? lastname = "";
while (string.IsNullOrEmpty(lastname))
{
    Console.WriteLine("Please enter lastname: ");
    lastname = Console.ReadLine();
}

Random random = new Random();
string randomDigits = random.Next(0, 1000).ToString("D3");

string username = $"{firstname[0]}{lastname[..2]}{randomDigits}".ToLower();
Console.WriteLine($"Your username is {username}");
