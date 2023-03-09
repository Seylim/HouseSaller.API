using Business.Abstracts;
using Entities.Dtos.Requests.AdDtos;
using Entities.Dtos.Requests.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IAdService _service;
        public AdController(IAdService service)
        {
            _service = service;
        }

        [Authorize(Roles = "AD.ADD")]
        [HttpPost("add")]
        public async Task<IActionResult> AddAd([FromBody] AddAdRequest request)
        {
            try
            {
                var result = await _service.AddAd(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [Authorize(Roles = "AD.DELETE")]
        [HttpPut("delete")]
        public async Task<IActionResult> DeleteAd([FromQuery] int id)
        {
            try
            {
                var request = new AdIdRequest { Id = id };
                await _service.DeleteAd(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "AD.UPDATE")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAd([FromBody] UpdateAdRequest request)
        {
            try
            {
                var result = await _service.UpdateAd(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getallads")]
        public async Task<IActionResult> GetAllAds()
        {
            try
            {
                var result = await _service.GetAllAds();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getadbyid")]
        public async Task<IActionResult> GetAdById([FromQuery] int id)
        {
            try
            {
                var request = new AdIdRequest { Id = id };
                var result = await _service.GetAdById(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getactiveads")]
        public async Task<IActionResult> GetActiveAds()
        {
            try
            {
                var request = await _service.GetAdsByIsActiveAsync();
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("getadsbycategoryid")]
        public async Task<IActionResult> GetAdsByCategoryId([FromQuery] int categoryId)
        {
            try
            {
                var request = new CategoryIdRequest { Id = categoryId };
                var result = await _service.GetAdsByCategoryIdAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
