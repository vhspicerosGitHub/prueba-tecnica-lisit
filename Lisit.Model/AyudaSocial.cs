using System.Diagnostics.CodeAnalysis;

namespace Lisit.Models;

[ExcludeFromCodeCoverage]
public class AyudaSocial : Base.NamedObject {
    public string? Descripcion { set; get; }
    public int ComunaId { set; get; }
}
