using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Weather.Model;
using Weather.Entity;
namespace Weather.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherAPIDbContext dbContext;
        private readonly ILogger<WeatherRepository> logger;
        public WeatherRepository(WeatherAPIDbContext DbContext, ILogger<WeatherRepository> logger)
        {
            this.dbContext = DbContext;
            this.logger = logger;
        }

        public async Task<List<GetUserReuest>> GetSavedLocations(Guid id)
        {
            var savedata = await this.dbContext.WeatherForecastModels.Select(g=>g.AsModel()).ToListAsync();
            return (savedata);
        }

        public async Task<AddUserRequest> AddSavedLocations(AddUserRequest addUserRequest)
        {
            var savelocation = new WeatherForecast()
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Weather = addUserRequest.Weather,
                Temperature = addUserRequest.Temperature,
                Humidity = addUserRequest.Humidity,
                Pressure = addUserRequest.Pressure,
                Location = addUserRequest.Location,
            };
            await dbContext.WeatherForecastModels.AddAsync(savelocation);
            await dbContext.SaveChangesAsync(); 
            return savelocation.AsEntity(); 
        }

        public async Task<UpdateUserRequest> UpdateSavedLocations(Guid id,UpdateUserRequest updateUserRequest) 
        {
            try
            {
                var weather_id = await dbContext.WeatherForecastModels.FindAsync(id);
                if (weather_id != null)
                {
                    weather_id.Location = updateUserRequest.Location;
                    await dbContext.SaveChangesAsync();
                    logger.LogWarning("Successfully updated data in the database.");
                    return weather_id.AsuModel();
                }
                throw new Exception("Error while updating weather data");

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong {ex}");
                throw;
            }            

        }

        public async Task<GetUserReuest> DeleteSavedLocations(Guid id) 
        {
            try {
                var delete_id = await dbContext.WeatherForecastModels.FindAsync(id);
                if (delete_id != null)
                {
                    dbContext.Remove(delete_id);
                    await dbContext.SaveChangesAsync();
                    logger.LogWarning("Successfully removed data from the database.");
                    return (delete_id.AsModel());
                }
                throw new Exception("Error while deleting weather data");

            }
           catch (Exception ex)
            {
                logger.LogError($"No data {ex}");
                throw;
            }
        }

        public async Task<List<GetUserReuest>> GetSavedLocationsByPagination(Paginator paginator)
        {
           
            if (paginator.Location != null)
            {
              var pagedData = await dbContext.WeatherForecastModels
                               .Skip((paginator.PageNumber - 1) * paginator.PageSize)
                               .Take(paginator.PageSize)
                               .Where(record => record.Location.ToLower().StartsWith(paginator.Location.ToLower()))
                               .OrderBy(sort => sort.Location)
                               .ToListAsync();
                return pagedData.Select(p => p.AsModel()).ToList();
            }
            else
            {
                 var pagedData1 = await dbContext.WeatherForecastModels
                              .Skip((paginator.PageNumber - 1) * paginator.PageSize)
                              .Take(paginator.PageSize)
                              .ToListAsync();
                return pagedData1.Select(p => p.AsModel()).ToList();
            }
                     
          
        }

    }
}
