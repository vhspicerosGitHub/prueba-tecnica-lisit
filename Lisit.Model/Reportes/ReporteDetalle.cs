using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lisit.Models.Reportes {
    public class ReporteDetalle {
        public string VecinoNombre { get; set; }
        public string VecinoEmail { get; set; }
        public string AyudaNombre { get; set; }
        public string AyudaDescripcion { get; set; }
        public int AyudaAño { get; set; }
        public DateTime fechaAsignacion { get; set; }
    }
}
