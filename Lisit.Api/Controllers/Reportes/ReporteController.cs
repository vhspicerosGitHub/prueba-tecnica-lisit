using Lisit.Api.Filters;
using Lisit.Models.Reportes;
using Lisit.Services.Interfaces.Reportes;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers.Reportes {
    /// <summary>
    /// Reportes del sistema
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase {
        private readonly ILogger<ReporteController> _logger;
        private readonly IReportesServices services;
        public ReporteController(ILogger<ReporteController> logger, IReportesServices services) {
            _logger = logger;
            this.services = services;
        }

        /// <summary>
        /// Obtiene todas las ayudas sociales por un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [ServiceFilter(typeof(AdministradorAuthorization))]
        [HttpGet("{idUSuario:int}")]
        [ProducesResponseType(typeof(IEnumerable<ReporteDetalle>), 200)]
        public async Task<IActionResult> ObtienePorUsuario([FromRoute] int idUsuario) {
            var l = await services.GetByUser(idUsuario);
            return Ok(l);
        }

        /// <summary>
        /// Obtiene todas ayudas sociales por un usuario en un año en particular
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="año"></param>
        /// <returns></returns>
        [ServiceFilter(typeof(AdministradorAuthorization))]
        [HttpGet("{idUSuario:int}/{año:int}")]
        [ProducesResponseType(typeof(IEnumerable<ReporteDetalle>), 200)]
        public async Task<IActionResult> ObtienePorUsuario([FromRoute] int idUsuario, [FromRoute] int año) {
            var l = await services.GetByUserAndYear(idUsuario, año);
            return Ok(l);
        }

        /// <summary>
        /// Obtiene todas ayudas sociales asignadas en un año (de todos los usuarios)
        /// </summary>
        /// <param name="año"></param>
        /// <returns></returns>
        [ServiceFilter(typeof(AdministradorAuthorization))]
        [HttpGet("año/{año:int}")]
        [ProducesResponseType(typeof(IEnumerable<ReporteDetalle>), 200)]
        public async Task<IActionResult> ObtienePorAño([FromRoute] int año) {
            var l = await services.GetByear(año);
            return Ok(l);
        }
    }
}
