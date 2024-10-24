using ConcertsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcertsApp;

// This way of setting up the database and seeding is inspired by the blazor sample from microsoft:
// https://github.com/dotnet/blazor-samples/tree/main/8.0/BlazorWebAppEFCore

public class DatabaseUtility
{
    // Method to see the database. Should not be used in production: demo purposes only.
    // options: The configured options.
    // count: The number of concerts to seed.
    public static async Task EnsureDbCreatedAndSeedWithCountOfAsync(DbContextOptions<ConcertContext> options, int count)
    {
        // Empty to avoid logging while inserting (otherwise will flood console).
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<ConcertContext>(options)
            .UseLoggerFactory(factory);

        using var context = new ConcertContext(builder.Options);
        // Result is true if the database had to be created.
        if (await context.Database.EnsureCreatedAsync())
        {
            var seed = new SeedConcerts();
            await seed.SeedDatabaseWithConcertCountOfAsync(context, count);
        }
    }
}