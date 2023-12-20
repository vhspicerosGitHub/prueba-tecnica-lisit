using Dapper;
using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Lisit.Repositories.SqlLiteRepositories;
public class AyudaSocialAsignacionRepository : Base.BaseRepository, IAyudaSocialAsignacionRepository {
    public AyudaSocialAsignacionRepository(IConfiguration configuration) : base(configuration) {
    }

    public async Task<int> Create(AyudaSocialAsignacion asignacion) {

        return await GetConnection().ExecuteScalarAsync<int>(Queries.AyudaSocialAsignacion.Create,
        new { usuarioId = asignacion.ResidenteId, ayudaId = asignacion.AyudaSocialId, year = asignacion.AñoAsignacion });
    }

    public async Task<IEnumerable<AyudaSocialAsignacion>> ObtieneAsignaciones(int idusuario, int idAyudaSocial, int año) {
        return await GetConnection().QueryAsync<AyudaSocialAsignacion>(Queries.AyudaSocialAsignacion.ObtieneAsignacion,
            new { usuarioId = idusuario, ayudaId = idAyudaSocial, year = año });
    }
}
