using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ConcertsApp.Data;

public class ConcertContext : DbContext
{
    // Magic string.
    public static readonly string RowVersion = nameof(RowVersion);
    
    // Magic strings.
    public static readonly string ConcertsDb = nameof(ConcertsDb).ToLower();

    // Inject options.
    public ConcertContext(DbContextOptions<ConcertContext> options) : base(options)
    {
        Debug.WriteLine($"{ContextId} context created.");
    }
    
    public DbSet<Concert>? Concerts { get; set; }
    
    // Define model.
    // modelBuilder: The ModelBuilder.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This property isn't on the C# class,
        // so we set it up as a "shadow" property and use it for concurrency.
        modelBuilder.Entity<Concert>()
            .Property<byte[]>(RowVersion)
            .IsRowVersion();

        base.OnModelCreating(modelBuilder);
    }
    
    // Dispose pattern.
    public override void Dispose()
    {
        Debug.WriteLine($"{ContextId} context disposed.");
        base.Dispose();
    }

    // Dispose pattern.
    public override ValueTask DisposeAsync()
    {
        Debug.WriteLine($"{ContextId} context disposed async.");
        return base.DisposeAsync();
    }
}