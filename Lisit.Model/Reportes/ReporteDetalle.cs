using System.Diagnostics.CodeAnalysis;

namespace Lisit.Models.Reportes;

[ExcludeFromCodeCoverage]
public class ReporteDetalle {
    public string VecinoNombre { get; set; }
    public string VecinoEmail { get; set; }
    public string AyudaNombre { get; set; }
    public string AyudaDescripcion { get; set; }
    public int AyudaAño { get; set; }
    public DateTime FechaAsignacion { get; set; }
}
