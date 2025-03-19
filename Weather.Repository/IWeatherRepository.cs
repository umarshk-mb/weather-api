using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Entity;
using Weather.Model;

namespace Weather.Repository
{
    public interface IWeatherRepository
    {
        Task<List<GetUserReuest>> GetSavedLocations(Guid id);
        Task<AddUserRequest> AddSavedLocations(AddUserRequest addUserRequest);
        Task<UpdateUserRequest> UpdateSavedLocations(Guid id,UpdateUserRequest updateUserRequest);
        Task<GetUserReuest> DeleteSavedLocations(Guid id);
        Task<List<GetUserReuest>> GetSavedLocationsByPagination(Paginator paginator);
    }
}
