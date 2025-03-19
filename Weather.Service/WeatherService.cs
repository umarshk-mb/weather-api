using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Entity;
using Weather.Model;
using Weather.Repository;

namespace Weather.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;
        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserReuest>> GetSavedLocations(Guid id)
        {
            return await _repository.GetSavedLocations(id);
        }

        public async Task<AddUserRequest> AddSavedLocations(AddUserRequest addUserRequest)
        {
            return (await _repository.AddSavedLocations(addUserRequest));
        }

        public async Task<UpdateUserRequest> UpdateSavedLocations(Guid id, UpdateUserRequest updateUserRequest)
        {
            return await _repository.UpdateSavedLocations(id, updateUserRequest);

        }

        public async Task<GetUserReuest> DeleteSavedLocations(Guid id)
        {
            return await _repository.DeleteSavedLocations(id);
        }

        public async Task<List<GetUserReuest>> GetSavedLocationsByPagination(Paginator paginator) 
        {
            return await _repository.GetSavedLocationsByPagination(paginator);
        }
    }
}
