using Business.Abstracts;
using Entities.Dtos.Requests.OperationClaimDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OperationClaimController : ControllerBase
    {
        private readonly IOperationClaimService _service;

        public OperationClaimController(IOperationClaimService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOperationClaim([FromBody] AddOperationClaimRequest request)
        {
            try
            {
                var result = await _service.AddOperationClaim(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteOperationClaim([FromQuery] OperationClaimIdRequest request)
        {
            try
            {
                await _service.DeleteOperationClaim(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getalloperationclaims")]
        public async Task<IActionResult> GetAllOperationClaims()
        {
            try
            {
                var result = await _service.GetAllOperationClaims();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getalloperationclaimbyid")]
        public async Task<IActionResult> GetAllOperationClaimById([FromQuery] OperationClaimIdRequest request)
        {
            try
            {
                var result = await _service.GetOperationClaimById(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateOperationClaim([FromBody] UpdateOperationClaimRequest request)
        {
            try
            {
                var result = await _service.UpdateOperationClaim(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
