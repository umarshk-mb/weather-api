namespace WeatherForecast.DTOs
{
    public class PaginatorDTO
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 

        public string ?Location { get; set; } 

    }
}
