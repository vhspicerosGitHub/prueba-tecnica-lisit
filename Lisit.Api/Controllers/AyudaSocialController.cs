using Lisit.Api.Filters;
using Lisit.Api.ViewModel.AyudaSocial;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AyudaSocial = Lisit.Api.ViewModel.AyudaSocial.AyudaSocial;

namespace Lisit.Api.Controllers;

/// <summary>
/// Servicio de Ayuda social
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AyudaSocialController : ControllerBase {

    private readonly ILogger<AyudaSocialController> _logger;
    private readonly IAyudaSocialServices _services;
    private readonly IAyudaSocialAsignacionServices _asignacionServices;

    public AyudaSocialController(IAyudaSocialServices ayudaSocialServices, IAyudaSocialAsignacionServices asignacionServices, ILogger<AyudaSocialController> logger) {
        _services = ayudaSocialServices;
        _logger = logger;
        _asignacionServices = asignacionServices;
    }
    /// <summary>
    /// Crea una ayuda Social a una comuna
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPost]
    public async Task<IActionResult> CreateByComuna([FromBody] AyudaSocialPorComuna request) {
        var id = await _services.Crear(new Models.AyudaSocial {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            ComunaId = request.ComunaId
        });
        return Ok(id);
    }

    /// <summary>
    /// Crea una ayuda social por Region (la crea a todas las comunas al interior de una region)
    /// </summary>
    /// <param name="idRegion"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPost("{idRegion:int}/Create")]
    public async Task<IActionResult> CreateByComuna([FromRoute] int idRegion, [FromBody] AyudaSocial request) {
        await _services.CrearPorRegion(idRegion, new Models.AyudaSocial {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion
        });
        return Ok();
    }

    /// <summary>
    /// Crea una Asignacion de ayuda Social a un residente
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [ServiceFilter(typeof(AdministradorAuthorization))]
    [HttpPost("Asignar")]
    public async Task<IActionResult> Asignar([FromBody] AyudaSocialAsignacion request) {
        var id = await _asignacionServices.Crear(new Models.AyudaSocialAsignacion { ResidenteId = request.IdUsuario, AyudaSocialId = request.IdAyuda, AñoAsignacion = request.Año });
        return Ok(id);
    }
}

