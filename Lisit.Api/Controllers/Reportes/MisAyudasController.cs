using System.Security.Claims;
using Lisit.Api.Filters;
using Lisit.Models.Reportes;
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
        public MisAyudasController(ILogger<ReporteController> logger, IReportesServices services) {
            _logger = logger;
            this.services = services;
        }

        private int GetConnectedUserID() {
            var user = HttpContext.User;
            var userId = Convert.ToInt16(user.Claims.ToList().FirstOrDefault(x => (x.Type == ClaimTypes.NameIdentifier)).Value);
            return userId;
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
            var l = await services.GetByUserAndYear(GetConnectedUserID(), año);
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
            var l = await services.GetByUserAndYear(GetConnectedUserID(), DateTime.Now.Year);
            return Ok(l);
        }
    }
}
