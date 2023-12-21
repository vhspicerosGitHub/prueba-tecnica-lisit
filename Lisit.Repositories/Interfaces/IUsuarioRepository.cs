using Lisit.Models;

namespace Lisit.Repositories.Interfaces;
public interface IUsuarioRepository {
    public Task<Usuario?> GetById(int id);

    public Task<Usuario?> GetByEmail(string email);

    public Task<int> Create(Usuario usuario);

    Task<IEnumerable<Usuario>> GetAll();
}
