using Lisit.Models.Base;

namespace Lisit.Models;
public class Usuario : NamedObject {

    public string? Email { set; get; }
    public string? Password { set; get; }
    public int ComunaId { set; get; }
    public bool EsAdministrador { set; get; }
}
