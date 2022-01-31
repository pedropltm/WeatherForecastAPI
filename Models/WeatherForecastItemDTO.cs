namespace WeatherForecastAPI.Models
{
    public class WeatherForecastItemDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}