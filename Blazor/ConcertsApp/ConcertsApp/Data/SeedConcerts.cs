namespace ConcertsApp.Data;

public class SeedConcerts
{
    // One option to making list of strings.
    private readonly string[] _countries =
    [
        "Norway", 
        "Sweden", 
        "Denmark", 
        "Poland",
        "US",
        "Germany"
    ];
    
    // Second option. Choose whatever you find best.
    private readonly string[] _cities = new[]
    {
        "Oslo", 
        "Tromsø", 
        "Narvik", 
        "Stockholm", 
        "Copenhagen", 
        "Gdansk"
    };
    
    private readonly string[] _scenes = new[]
    {
        "Telenor Arena", 
        "Tromsø Sentrum", 
        "Haikjeften", 
        "Stockholm Theater", 
        "Copenhagen Stadium", 
        "Gdansk Outdoor Arena"
    };
    
    private readonly DateOnly _startDate = DateOnly.FromDateTime(DateTime.Now);
    
    private string RandomOne(string[] list)
    {
        var idx = Random.Shared.Next(list.Length);
        return list[idx];
    }

    private Concert MakeConcert()
    {
        var concert = new Concert
        {
            Country = RandomOne(_countries),
            City = RandomOne(_cities),
            Date = _startDate.AddDays(Random.Shared.Next(0, 365)),
            Scene = RandomOne(_scenes)
        };

        return concert;
    }

    public async Task SeedDatabaseWithConcertCountOfAsync(ConcertContext context, int totalCount)
    {
        var count = 0;
        var currentCycle = 0;
        while (count < totalCount)
        {
            var list = new List<Concert>();
            while (currentCycle++ < 100 && count++ < totalCount)
            {
                list.Add(MakeConcert());
            }
            if (list.Count > 0)
            {
                context.Concerts?.AddRange(list);
                await context.SaveChangesAsync();
            }
            currentCycle = 0;
        }
    }
}