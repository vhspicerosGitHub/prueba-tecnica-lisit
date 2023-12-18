using Lisit.Common;
using Lisit.Model;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {

        public readonly IRegionServices _service;
        public readonly ILogger<RegionController> _logger;
        public RegionController(IRegionServices service, ILogger<RegionController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Region>), 200)]
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
        [ProducesResponseType(typeof(Region), 200)]
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
        public async Task<IActionResult> Create(Region region)
        {
            try
            {
                return Ok(await _service.Create(region));
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