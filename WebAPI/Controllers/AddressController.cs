using Business.Abstracts;
using Entities.Dtos.Requests.AddressDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Member")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAddress([FromBody] AddAddressRequest request)
        {
            try
            {
                var result = await _service.AddAddress(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
            }
        }

        [HttpPut("delete")]
        public async Task<IActionResult> DeleteAddress([FromQuery] int id)
        {
            try
            {
                var request = new AddressIdRequest { Id = id };
                await _service.DeleteAddress(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressRequest request)
        {
            try
            {
                var result = await _service.UpdateAddress(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getalladdresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            try
            {
                var result = await _service.GetAllAddresses();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getaddressbyid")]
        public async Task<IActionResult> GetAddresses([FromQuery] int id)
        {
            try
            {
                var request = new AddressIdRequest { Id = id }; 
                var result = await _service.GetAddressById(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getactiveaddresses")]
        public async Task<IActionResult> GetActiveAddresses()
        {
            try
            {
                var result = await _service.GetAddressesByIsActiveAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
