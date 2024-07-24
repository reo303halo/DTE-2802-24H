namespace Oppgave3;

// internal brukes da klassen er i samme fil som den brukes(i dette tilfellet main): Ofte defineres klasser i egne filer
internal class Organism
{ 
    public virtual void MakeSound()
    {
        Console.WriteLine("Unknown sound");
    }
}

internal class Mammal : Organism
{
    public override void MakeSound()
    {
        Console.WriteLine("Mammals make sounds");
    }
}

internal class Human : Mammal
{
    public override void MakeSound()
    {
        Console.WriteLine("Hello!");
    }
}

internal class Dog : Mammal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof, woof!");
    }
}

internal class Sheep : Mammal
{
    public override void MakeSound()
    {
        Console.WriteLine("Baa, baa!");
    }
}

internal class Amphibian : Organism
{
    public override void MakeSound()
    {
        Console.WriteLine("Amphibians don't make as much sound (usually)!");
    }
}

internal class Frog : Amphibian
{
    public override void MakeSound()
    {
        Console.WriteLine("Ribbit, ribbit!");
    }
}

// Add more classes like Insect, Monkey, Snake, Spider, and Mosquito here

internal static class Program
{
    private static void Main()
    {
        Organism[] species = {
            new Human(),
            new Dog(),
            new Frog(),
            new Sheep()
            // Add instances of other classes here
        };

        foreach (var creature in species)
        {
            creature.MakeSound();
        }
    }
}