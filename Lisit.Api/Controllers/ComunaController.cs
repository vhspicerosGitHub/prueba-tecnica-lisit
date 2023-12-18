using Lisit.Common;
using Lisit.Model;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunaController : ControllerBase
    {
        public readonly IComunaServices _service;
        public readonly ILogger<ComunaController> _logger;
        public ComunaController(IComunaServices service, ILogger<ComunaController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Comuna>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var test = User.Identity?.Name;
                return Ok(await _service.GetAll());
            }
            catch (BusinessException e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode((int)e.HttpStatusCode, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Comuna), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (BusinessException e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode((int)e.HttpStatusCode, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create(Comuna comuna)
        {
            try
            {
                return Ok(await _service.Create(comuna));
            }
            catch (BusinessException e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode((int)e.HttpStatusCode, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}