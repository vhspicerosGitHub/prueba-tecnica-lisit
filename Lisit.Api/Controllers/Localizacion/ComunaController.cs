using Lisit.Api.Filters;
using Lisit.Models.Localizacion;
using Lisit.Services.Interfaces.Localizacion;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers;

/// <summary>
/// Servicio de Localizacion (Comuna)
/// </summary>
[Route("api/[controller]")]
[ApiController]
public partial class ComunaController : ControllerBase {
    public readonly IComunaServices _service;
    public readonly ILogger<ComunaController> _logger;
    public ComunaController(IComunaServices service, ILogger<ComunaController> logger) {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene Todas las Comunas
    /// </summary>
    /// <returns></returns>
    [ServiceFilter(typeof(UsuarioAuthorization))]
    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<Comuna>), 200)]
    public async Task<IActionResult> Get() {
        return Ok(await _service.GetAll());
    }

    /// <summary>
    /// Obtiene todas las comunas por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(UsuarioAuthorization))]
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Comuna), 200)]
    public async Task<IActionResult> GetById(int id) {
        return Ok(await _service.GetById(id));
    }

    /// <summary>
    /// Crea una comuna
    /// </summary>
    /// <param name="comuna"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPost()]
    [ProducesResponseType(typeof(int), 200)]
    public async Task<IActionResult> Create(Comuna comuna) {
        return Ok(await _service.Create(comuna));
    }

    /// <summary>
    /// Elimina una comuna
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
    /// Edita una comuna
    /// </summary>
    /// <param name="comuna"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(Comuna comuna) {
        await _service.Update(comuna);
        return Ok();
    }
}
