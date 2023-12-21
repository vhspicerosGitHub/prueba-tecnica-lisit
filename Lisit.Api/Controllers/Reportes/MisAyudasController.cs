using System.Security.Claims;
using Lisit.Api.Filters;
using Lisit.Api.Utils;
using Lisit.Models.Reportes;
using Lisit.Services.Interfaces;
using Lisit.Services.Interfaces.Reportes;
using Microsoft.AspNetCore.Mvc;

namespace Lisit.Api.Controllers.Reportes {
    /// <summary>
    /// Servicio para obtener mis ayudas sociales
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MisAyudasController : ControllerBase {
        private readonly ILogger<ReporteController> _logger;
        private readonly IReportesServices services;
        private readonly ILogNegocioServices logNegocioServices;

        public MisAyudasController(ILogger<ReporteController> logger, IReportesServices services, ILogNegocioServices logNegocioServices) {
            _logger = logger;
            this.services = services;
            this.logNegocioServices = logNegocioServices;
        }

        /// <summary>
        /// Obtiene mis ayudas sociales asignadas en un año en particular
        /// </summary>
        /// <param name="año"></param>
        /// <returns></returns>
        [ServiceFilter(typeof(UsuarioAuthorization))]
        [HttpGet("{año:int}")]
        [ProducesResponseType(typeof(IEnumerable<ReporteDetalle>), 200)]
        public async Task<IActionResult> MisAsignaciones([FromRoute] int año) {
            await logNegocioServices.Create(new Models.LogNegocio { UsuarioId = HttpContext.GetConnectedUserId(), Accion = $"Consulta mis asignaciones para el año {año}" });
            var l = await services.GetByUserAndYear(HttpContext.GetConnectedUserId(), año);
            return Ok(l);
        }

        /// <summary>
        /// Obtiene mis ayudas sociales asignadas en el presente año
        /// </summary>
        /// <returns></returns>
        [ServiceFilter(typeof(UsuarioAuthorization))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReporteDetalle>), 200)]
        public async Task<IActionResult> MisAsignacionesUltimoAño() {
            await logNegocioServices.Create(new Models.LogNegocio { UsuarioId = HttpContext.GetConnectedUserId(), Accion = $"Consulta mis asignaciones para el año actual" });
            var l = await services.GetByUserAndYear(HttpContext.GetConnectedUserId(), DateTime.Now.Year);
            return Ok(l);
        }
    }
}
