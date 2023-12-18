using Lisit.Models;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase {

        public readonly IRegionServices _service;
        public readonly ILogger<RegionController> _logger;
        public RegionController(IRegionServices service, ILogger<RegionController> logger) {
            _service = service;
            _logger = logger;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Region>), 200)]
        public async Task<IActionResult> Get() {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Region), 200)]
        public async Task<IActionResult> GetById(int id) {
            return Ok(await _service.GetById(id));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create(Region region) {
            return Ok(await _service.Create(region));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(Region region) {
            await _service.Update(region);
            return Ok();
        }
    }
}