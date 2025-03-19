using Weather.Entity;
using Weather.Model;

namespace Weather.Repository
{
    public static class Extensions
    {
        
        public static AddUserRequest AsEntity (this WeatherForecast weatherForecast) 
        {
            return new AddUserRequest
            {
                Humidity = weatherForecast.Humidity,
                Location = weatherForecast.Location,
                Pressure = weatherForecast.Pressure,
                Temperature = weatherForecast.Temperature,
                Weather = weatherForecast.Weather,
            };
        }

        public static GetUserReuest AsModel(this WeatherForecast weatherForecast)
        {
            return new GetUserReuest
            {
                Id = weatherForecast.Id,
                Location = weatherForecast.Location,
                Temperature = weatherForecast.Temperature,
                Weather = weatherForecast.Weather,
                DateTime = weatherForecast.DateTime,
            };
        }

        public static UpdateUserRequest AsuModel(this WeatherForecast weatherForecast)
        {
            return new UpdateUserRequest
            {
                Location = weatherForecast.Location,
            };
        }

    
      
        
    }
}
