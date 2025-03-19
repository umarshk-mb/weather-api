using Weather.Entity;
using Weather.Model;

namespace Weather.Service
{
    public interface IWeatherService
    {
        public Task<List<GetUserReuest>> GetSavedLocations(Guid id);

        public Task<AddUserRequest> AddSavedLocations(AddUserRequest addUserRequest);

        public Task<UpdateUserRequest> UpdateSavedLocations(Guid id, UpdateUserRequest updateUserRequest);

        public Task<GetUserReuest> DeleteSavedLocations(Guid id);

        public Task<List<GetUserReuest>> GetSavedLocationsByPagination(Paginator paginator);
    }
}
