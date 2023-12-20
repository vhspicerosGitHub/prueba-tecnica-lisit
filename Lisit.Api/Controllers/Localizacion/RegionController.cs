using Lisit.Api.Filters;
using Lisit.Models.Localizacion;
using Lisit.Services.Interfaces.Localizacion;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers.Localizacion;

/// <summary>
/// Servicio de Localizacion (Region)
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RegionController : ControllerBase {

    public readonly IRegionServices _service;
    public readonly ILogger<RegionController> _logger;
    public RegionController(IRegionServices service, ILogger<RegionController> logger) {
        _service = service;
        _logger = logger;
    }


    /// <summary>
    /// Obtiene todas las regiones
    /// </summary>
    /// <returns></returns>
    [ServiceFilter(typeof(UsuarioAuthorization))]
    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<Region>), 200)]
    public async Task<IActionResult> Get() {
        return Ok(await _service.GetAll());
    }

    /// <summary>
    /// Obtiene una region por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(UsuarioAuthorization))]
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Region), 200)]
    public async Task<IActionResult> GetById(int id) {
        return Ok(await _service.GetById(id));
    }

    /// <summary>
    /// Crea una region
    /// </summary>
    /// <param name="region"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPost()]
    [ProducesResponseType(typeof(int), 200)]
    public async Task<IActionResult> Create(Region region) {
        return Ok(await _service.Create(region));
    }

    /// <summary>
    /// Elimina una region
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) {
        await _service.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Actualiza una region
    /// </summary>
    /// <param name="region"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(Region region) {
        await _service.Update(region);
        return Ok();
    }
}
