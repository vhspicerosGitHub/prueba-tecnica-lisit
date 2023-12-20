using Lisit.Api.Filters;
using Lisit.Models.Localizacion;
using Lisit.Services.Interfaces.Localizacion;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers.Localizacion;
/// <summary>
/// Servicio de Localizacion (Pais)
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PaisController : ControllerBase {

    public readonly IPaisServices _service;
    public readonly ILogger<PaisController> _logger;
    public PaisController(IPaisServices service, ILogger<PaisController> logger) {
        _service = service;
        _logger = logger;
    }


    /// <summary>
    /// Obtiene todos los paises
    /// </summary>
    /// <returns></returns>
    [ServiceFilter(typeof(UsuarioAuthorization))]
    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<Pais>), 200)]
    public async Task<IActionResult> Get() {
        return Ok(await _service.GetAll());
    }

    /// <summary>
    /// Obtiene un pais por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(UsuarioAuthorization))]
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Pais), 200)]
    public async Task<IActionResult> GetById(int id) {
        return Ok(await _service.GetById(id));
    }

    /// <summary>
    /// Crea un pais
    /// </summary>
    /// <param name="pais"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPost()]
    [ProducesResponseType(typeof(int), 200)]
    public async Task<IActionResult> Create(Pais pais) {
        return Ok(await _service.Create(pais));
    }

    /// <summary>
    /// Elimina un pais
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
    /// Actualiza un pais
    /// </summary>
    /// <param name="pais"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(Pais pais) {
        await _service.Update(pais);
        return Ok();
    }
}
