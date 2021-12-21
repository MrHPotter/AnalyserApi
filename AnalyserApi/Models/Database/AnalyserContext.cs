using Microsoft.EntityFrameworkCore;

namespace AnalyserApi.Models.Database;

public class AnalyserContext : DbContext
{
    public AnalyserContext(DbContextOptions<AnalyserContext> options) : base(options)
    {

    }
    public DbSet<PriceEntry> PriceEntries => Set<PriceEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriceEntry>().HasKey(entry => new { entry.Symbol, entry.DateAndTime });

        base.OnModelCreating(modelBuilder);
    }
}