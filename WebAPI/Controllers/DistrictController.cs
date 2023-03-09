using Business.Abstracts;
using Entities.Dtos.Requests.CityDtos;
using Entities.Dtos.Requests.DistrictDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _service;

        public DistrictController(IDistrictService service)
        {
            _service = service;
        }

        [Authorize(Roles = "DISTRICT.ADD")]
        [HttpPost("add")]
        public async Task<IActionResult> AddDistrict([FromBody] AddDistrictRequest request)
        {
            try
            {
                var result = await _service.AddDistrict(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "DISTRICT.UPDATE")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateDistrict([FromBody] UpdateDistrictRequest request)
        {
            try
            {
                var result = await _service.UpdateDistrict(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getalldistricts")]
        public async Task<IActionResult> GetAllDistricts()
        {
            try
            {
                var result = await _service.GetAllDistricts();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [AllowAnonymous]
        [HttpGet("getdistrictbyid")]
        public async Task<IActionResult> GetDistrictById([FromQuery] int id)
        {
            try
            {
                var districtRequest = new DistrictIdRequest { Id = id };
                var result = await _service.GetDistrictById(districtRequest);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getdistrictbyname")]
        public async Task<IActionResult> GetDistrictByName([FromQuery] string name)
        {
            try
            {
                var request = new DistrictNameRequest { Name = name };
                var result = await _service.GetDistrictByNameAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getdistrictbycityid")]
        public async Task<IActionResult> GetDistrictByCityId([FromQuery] int cityId)
        {
            try
            {
                var request = new CityIdRequest { Id = cityId };
                var result = await _service.GetDistrictByCityIdAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getparentdistrictbydistrictid")]
        public async Task<IActionResult> GetParentDistrictByDistrictId([FromQuery] int districtId)
        {
            try
            {
                var request = new DistrictIdRequest { Id = districtId };
                var result = await _service.GetParentDistrictByDistrictIdAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getsubdistrictsbydistrictid")]
        public async Task<IActionResult> GetSubDistrictsByDistrictId([FromQuery] int districtId)
        {
            try
            {
                var request = new DistrictIdRequest { Id = districtId };
                var result = await _service.GetSubDistrictsByDistrictIdAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
