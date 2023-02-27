using Business.Abstracts;
using Entities.Dtos.Requests.UserOperationClaimDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserOperationClaimController : ControllerBase
    {
        private readonly IUserOperationClaimService _service;

        public UserOperationClaimController(IUserOperationClaimService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUserOperationClaim([FromBody] AddUserOperationClaimRequest request)
        {
            try
            {
                var result = await _service.AddUserOperationClaim(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUserOperationClaim([FromQuery] UserOperationClaimIdRequest request)
        {
            try
            {
                await _service.DeleteUserOperationClaim(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getalluseroperationclaims")]
        public async Task<IActionResult> GetAllUserOperationClaims()
        {
            try
            {
                var result = await _service.GetAllUserOperationClaims();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getalluseroperationclaimbyid")]
        public async Task<IActionResult> GetAllUserOperationClaimById([FromQuery] UserOperationClaimIdRequest request)
        {
            try
            {
                var result = await _service.GetUserOperationClaimById(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
