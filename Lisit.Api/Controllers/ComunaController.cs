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
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Comuna), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create(Comuna comuna)
        {
            return Ok(await _service.Create(comuna));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(Comuna comuna)
        {
            await _service.Update(comuna);
            return Ok();
        }
    }
}