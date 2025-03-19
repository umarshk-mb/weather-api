using System.Security.Cryptography.X509Certificates;
using Weather.Model;
using WeatherForecast.DTOs;

namespace WeatherForecast.Mappers
{
    public static class WeatherForecastExtension
    {       
        public static AddUserRequest AsModel(this AddUserRequestDTO addUserRequestDTO) {
            return new AddUserRequest() { 
                Humidity= addUserRequestDTO.Humidity,
                Location= addUserRequestDTO.Location,   
                Pressure= addUserRequestDTO.Pressure,
                Temperature= addUserRequestDTO.Temperature, 
                Weather = addUserRequestDTO.Weather                
            };       
        
        }    

        public static UpdateUserRequest ToModel(this UpdateUserRequestDTO updateUserRequestDTO)
        {
            return new UpdateUserRequest
            {
                Location = updateUserRequestDTO.Location,
            };
        }

        public static Paginator AsDTO(this PaginatorDTO paginationDTO)
        {
            return new Paginator
            {
                PageSize= paginationDTO.PageSize,
                PageNumber = paginationDTO.PageNumber,
                Location = paginationDTO.Location,
            };
        }

        public static GetUserReuest AsDTO(this GetUserRequestDTO getUserRequestDTO)
        {
            return new GetUserReuest
            {
                DateTime = getUserRequestDTO.DateTime,
                Id= getUserRequestDTO.Id,
                //Humidity= getUserRequestDTO.Humidity,
                Location = getUserRequestDTO.Location,
                Temperature = getUserRequestDTO.Temperature,
                Weather = getUserRequestDTO.Weather

            };
        }
    }

    
}
