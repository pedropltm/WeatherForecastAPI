using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace WeatherForecastAPI.Models
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecastItem> WeatherForecastItems { get; set; } = null!;
    }
}