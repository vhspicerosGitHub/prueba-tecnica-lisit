using Lisit.Models;

namespace Lisit.Services.Interfaces;
public interface IAuthServices {

    Task<Usuario> Login(string? email, string? password);

    Task<int> Registrar(Usuario usuario);

    Task<IEnumerable<Usuario>> GetAll();
}
