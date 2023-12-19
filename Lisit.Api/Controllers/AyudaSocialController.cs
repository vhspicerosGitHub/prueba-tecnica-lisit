using Lisit.Api.ViewModel.AyudaSocial;
using Lisit.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AyudaSocial = Lisit.Api.ViewModel.AyudaSocial.AyudaSocial;

namespace Lisit.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AyudaSocialController : ControllerBase {

    private readonly ILogger<AyudaSocialController> _logger;
    private readonly IAyudaSocialServices _services;

    public AyudaSocialController(IAyudaSocialServices ayudaSocialServices, ILogger<AyudaSocialController> logger) {
        _services = ayudaSocialServices;
        _logger = logger;

    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateByComuna([FromBody] AyudaSocialPorComuna request) {
        var id = await _services.Crear(new Models.AyudaSocial {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            ComunaId = request.ComunaId
        });
        return Ok(id);
    }

    [HttpPost("{idRegion:int}/Create")]
    public async Task<IActionResult> CreateByComuna([FromRoute] int idRegion, [FromBody] AyudaSocial request) {
        await _services.CrearPorRegion(idRegion, new Models.AyudaSocial {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion
        });
        return Ok();
    }


}


