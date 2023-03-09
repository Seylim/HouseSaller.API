using Business.Abstracts;
using Entities.Dtos.Requests.CityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [Authorize(Roles = "CITY.ADD")]
        [HttpPost("add")]
        public async Task<IActionResult> AddCity(AddCityRequest request)
        {
            try
            {
                var result = await _service.AddCity(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "CITY.UPDATE")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCity(UpdateCityRequest request)
        {
            try
            {
                var result = await _service.UpdateCity(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getallcities")]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var result = await _service.GetAllCities();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getcitybyid")]
        public async Task<IActionResult> GetCityById([FromQuery] int id)
        {
            try
            {
                var cityRequest = new CityIdRequest { Id = id };
                var result = await _service.GetCityById(cityRequest);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getcitybyname")]
        public async Task<IActionResult> GetCityByName([FromQuery] string name)
        {
            try
            {
                var request = new CityNameRequest { Name = name };
                var result = await _service.GetCityByNameAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
