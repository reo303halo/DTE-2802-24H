namespace ConcertsApp.Data;

public class Concert
{
    public string Country { get; set; } = "TBA";
    public string City { get; set; } = "TBA";
    public DateOnly Date { get; set; }
    public string Scene { get; set; } = "TBA";
}