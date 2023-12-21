using Dapper;
using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Lisit.Repositories.SqlLiteRepositories;
public class LogNegocioRepository : Base.BaseRepository, ILogNegocioRepository {
    public LogNegocioRepository(IConfiguration configuration) : base(configuration) {
    }

    public async Task<int> Create(LogNegocio log) {
        return await GetConnection().ExecuteScalarAsync<int>(Queries.LogNegocio.Create, new { usuarioId = log.UsuarioId, accion = log.Accion });
    }

    public async Task<IEnumerable<LogNegocio>> GetAll() {
        return await GetConnection().QueryAsync<LogNegocio>(Queries.LogNegocio.GetAll, new { });
    }
}
