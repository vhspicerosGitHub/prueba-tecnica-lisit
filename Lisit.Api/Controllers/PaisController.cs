using Lisit.Models;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase {

        public readonly IPaisServices _service;
        public readonly ILogger<PaisController> _logger;
        public PaisController(IPaisServices service, ILogger<PaisController> logger) {
            _service = service;
            _logger = logger;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Pais>), 200)]
        public async Task<IActionResult> Get() {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Pais), 200)]
        public async Task<IActionResult> GetById(int id) {
            return Ok(await _service.GetById(id));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create(Pais pais) {
            return Ok(await _service.Create(pais));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(Pais pais) {
            await _service.Update(pais);
            return Ok();
        }
    }
}