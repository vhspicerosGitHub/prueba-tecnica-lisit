using Lisit.Models.Base;

namespace Lisit.Models {
    public class LogNegocio : IdentificableObject {
        public int UsuarioId { set; get; }
        public string Accion { set; get; }
        public DateTime FechaAccion { set; get; }

    }
}
