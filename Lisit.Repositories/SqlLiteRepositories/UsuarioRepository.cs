using Dapper;
using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Lisit.Repositories.SqlLiteRepositories.Base;
using Microsoft.Extensions.Configuration;

namespace Lisit.Repositories.SqlLiteRepositories;
public class UsuarioRepository : BaseRepository, IUsuarioRepository {

    public UsuarioRepository(IConfiguration configuration) : base(configuration) {
    }

    public async Task<int> Create(Usuario usuario) {
        return await GetConnection().ExecuteScalarAsync<int>(Queries.usuarios.Create,
            new { nombre = usuario.Nombre, email = usuario.Email, password = usuario.Password, comunaId = usuario.ComunaId, esAdministrador = usuario.EsAdministrador }
            );
    }

    public async Task<Usuario?> GetByEmail(string email) {
        return await GetConnection().QueryFirstOrDefaultAsync<Usuario>(Queries.usuarios.GetByEmail, new { email });
    }

    public async Task<Usuario?> GetById(int id) {
        return await GetConnection().QueryFirstOrDefaultAsync<Usuario>(Queries.usuarios.GetById, new { id });
    }

    public async Task<IEnumerable<Usuario>> GetAll() {
        return await GetConnection().QueryAsync<Usuario>(Queries.usuarios.GetAll, new { });
    }
}
