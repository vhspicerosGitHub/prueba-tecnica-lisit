using Lisit.Models.Base;

namespace Lisit.Models {
    public class AyudaSocialAsignacion : IdentificableObject {
        public int ResidenteId { get; set; }

        public int AyudaSocialId { get; set; }

        public int AñoAsignacion { set; get; }

        public DateTime FechaCreacion { set; get; }
    }
}
