
using Backend.Application.Responses;
using Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Backend.Domain.Entities;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;

        private readonly ILogger<ComponentController> _logger;

        public ComponentController(IComponentService componentService, ILogger<ComponentController> logger)
        {
            _componentService = componentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Component>>>> GetAllComponents()
        {
            var result = await _componentService.GetAllComponentsAsync();

            if(!result.Success)
            {
                _logger.LogWarning("GET /api/components failed: {msg}", result.Message);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Component>>> GetComponent(int id)
        {
            var result = await _componentService.GetComponentByIdAsync(id);

            if(!result.Success)
            {
                _logger.LogWarning("GET /api/components failed for id {id}: {message}", id, result.Message);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Component>>> CreateComponent(Component component)
        {
            var result = await _componentService.CreateComponentAsync(component);

            if(!result.Success)
            {
                _logger.LogWarning("POST /api/components failed: {message}", result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteComponent(int id)
        {
            var result = await _componentService.DeleteComponentAsync(id);

            if(!result.Success)
            {
                _logger.LogWarning("DELETE /api/components/ failed for id {id}: {message}", id, result.Message);
                return BadRequest(result);

            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Component>>> UpdateComponent(Component component)
        {
            var result = await _componentService.UpdateComponentAsync(component);

            if( !result.Success)
            {
                _logger.LogWarning("PUT /api/components failded: {message}", result.Message);
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}