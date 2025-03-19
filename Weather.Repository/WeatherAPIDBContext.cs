using Microsoft.EntityFrameworkCore;
using Weather.Entity;

namespace Weather.Repository
{
    public  class WeatherAPIDbContext : DbContext
    {
        //Entity
        public DbSet<WeatherForecast> WeatherForecastModels { get; set; }

        //Passing options to the Base class
        public WeatherAPIDbContext(DbContextOptions options) : base(options)
        {

        }
       
    }
}
