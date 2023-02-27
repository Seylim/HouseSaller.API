using Business.Abstracts;
using Entities.Dtos.Requests.AdDtos;
using Entities.Dtos.Requests.Photo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _service;

        public PhotoController(IPhotoService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin,Member")]
        [HttpPost("add")]
        public async Task<IActionResult> AddPhoto([FromQuery] AdIdRequest adIdRequest, IFormFile file, string description)
        {
            try
            {
                var photoForCreationRequest = new PhotoForCreationRequest { File= file, Description = description };
                var result = await _service.AddPhoto(adIdRequest, photoForCreationRequest);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [Authorize(Roles = "Admin,Member,Client")]
        [HttpGet("getphotobyadid")]
        public async Task<IActionResult> GetPhotoById(PhotoIdRequest request)
        {
            try
            {
                var result = await _service.GetPhoto(request);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
