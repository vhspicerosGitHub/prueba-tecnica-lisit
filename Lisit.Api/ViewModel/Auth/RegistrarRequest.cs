namespace Lisit.Api.ViewModel.Auth;
public class RegistrarRequest {
    public string? Nombre { set; get; }
    public string? Email { set; get; }
    public string? Password { set; get; }
    public bool EsAdministrador { set; get; }
    public int ComunaId { set; get; }
}
