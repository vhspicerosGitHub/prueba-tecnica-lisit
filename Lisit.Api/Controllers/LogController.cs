using Lisit.Api.Filters;
using Lisit.Models;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers;

/// <summary>
/// Obtiene log de autoria de acciones de los usuarios
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class LogController : ControllerBase {
    private readonly ILogNegocioServices _service;

    public LogController(ILogNegocioServices service) {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los log de auditoria
    /// </summary>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<LogNegocio>), 200)]
    public async Task<IActionResult> Get() {
        return Ok(await _service.GetAll());
    }

}

