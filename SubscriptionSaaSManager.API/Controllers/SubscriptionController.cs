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

    public class SubscriptionController(ISubscriptionService business, ILogger<SubscriptionController> logger) : Controller
    {
        private readonly ISubscriptionService _business = business;
        private readonly ILogger<SubscriptionController> _logger = logger;

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> Insert([FromBody] SubscriptionDTO subscription)
        {
            var response = await _business.Add(subscription);
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
        public async Task<IActionResult> Update([FromBody] SubscriptionDTO subscriptionDTO)
        {
            if (subscriptionDTO.Id < 1)
                return BadRequest(Error.ID);
            var response = await _business.Update(subscriptionDTO);
            IActionResult result = response.Success ? Ok(response) : BadRequest(response);
            return result;

        }
    }
}
