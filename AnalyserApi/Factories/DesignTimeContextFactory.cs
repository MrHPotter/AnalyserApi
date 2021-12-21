using AnalyserApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnalyserApi.Factories;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<AnalyserContext>
{
    public AnalyserContext CreateDbContext(string[] args)
    {
        return new AnalyserContext(new DbContextOptions<AnalyserContext>());
    }
}