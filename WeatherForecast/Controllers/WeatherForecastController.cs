using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Model;
using Weather.Service;
using WeatherForecast.DTOs;
using WeatherForecast.Mappers;

namespace WeatherForecast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        //Service
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }



        [HttpGet]
        public async Task<ActionResult<GetUserRequestDTO>> Get(Guid id)
        {
            var item = await _weatherService.GetSavedLocations(id);
            if (item == null) 
            {
                return NotFound();
            }
            return Ok(item);
            
        }


        [HttpPost]
        public async Task<ActionResult<AddUserRequestDTO>> Add(AddUserRequestDTO addUserRequestDTO)
        {
            var result = await _weatherService.AddSavedLocations(addUserRequestDTO.AsModel());
            return CreatedAtAction(nameof(Get), new { id = result.Pressure }, result);
        }


        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update(Guid id, UpdateUserRequestDTO updateUserRequestDTO)
        {
            var weather_id = await _weatherService.GetSavedLocations(id);
            if (weather_id == null)
            {
                return NotFound();
            }
            await _weatherService.UpdateSavedLocations(id, updateUserRequestDTO.ToModel());
            return NoContent();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = _weatherService.GetSavedLocations(id);
            if (item == null) {
                return NotFound();
            }
            await _weatherService.DeleteSavedLocations(id);
            return NoContent();
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<PaginatorDTO>> GetByPagination([FromQuery] PaginatorDTO paginatorDTO)
        {
            return Ok(await _weatherService.GetSavedLocationsByPagination(paginatorDTO.AsDTO()));
        }

    }
}