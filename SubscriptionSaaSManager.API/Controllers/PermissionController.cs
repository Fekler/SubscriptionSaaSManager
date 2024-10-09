using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionSaaSManager.Application.DTOS;
using SubscriptionSaaSManager.Application.Interfaces;
using SubscriptionSaaSManager.Domain.Validations;

namespace SubscriptionSaaSManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PermissionController(IPermissionService business, ILogger<PermissionController> logger) : Controller
    {
        private readonly IPermissionService _business = business;
        private readonly ILogger<PermissionController> _logger = logger;

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> Insert([FromBody] PermissionDTO permissionDTO)
        {
            var response = await _business.Add(permissionDTO);
            IActionResult result = response.Success ? Ok(response) : BadRequest(response);
            return result;

        }
        [HttpGet, Route("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
                return BadRequest(Error.ID);
            var response = await _business.Get(id);
            IActionResult result = response.Success ? Ok(response) : BadRequest(response);
            return result;

        }
        [HttpGet, Route("[action]")]
        public async Task<IActionResult> GetByGuid(Guid guid)
        {
            if (guid.Equals(Guid.Empty))
                return BadRequest(Error.ID);
            var response = await _business.Get(guid);
            IActionResult result = response.Success ? Ok(response) : BadRequest(response);
            return result;

        }

        [HttpDelete, Route("[action]")]
        public async Task<IActionResult> DeleteByGuid(Guid guid)
        {
            if (guid.Equals(Guid.Empty))
                return BadRequest(Error.ID);
            var response = await _business.Delete(guid);
            IActionResult result = response.Success ? Ok(response) : BadRequest(response);
            return result;

        }
        [HttpDelete, Route("[action]")]
        public async Task<IActionResult> DeleteById(int id)
        {
            if (id <= 0)
                return BadRequest(Error.ID);
            var response = await _business.Delete(id);
            IActionResult result = response.Success ? Ok(response) : BadRequest(response);
            return result;

        }
        [HttpPut, Route("[action]")]
        public async Task<IActionResult> Update([FromBody] PermissionDTO permissionDTO)
        {
            if (permissionDTO.Id < 1)
                return BadRequest(Error.ID);
            var response = await _business.Update(permissionDTO);
            IActionResult result = response.Success ? Ok(response) : BadRequest(response);
            return result;

        }
    }
}
