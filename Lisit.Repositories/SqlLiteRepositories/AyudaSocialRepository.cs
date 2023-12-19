using Dapper;
using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Lisit.Repositories.SqlLiteRepositories;
public class AyudaSocialRepository : Base.BaseRepository, IAyudaSocialRepository {
    public AyudaSocialRepository(IConfiguration configuration) : base(configuration) {
    }

    public async Task<int> Crear(AyudaSocial ayudaSocial) {
        return await GetConnection().ExecuteScalarAsync<int>(Queries.AyudaSocial.Create,
            new { nombre = ayudaSocial.Nombre, descripcion = ayudaSocial.Descripcion, comunaId = ayudaSocial.ComunaId });
    }

    public async Task CrearPorRegion(int regionId, AyudaSocial ayudaSocial) {
        await GetConnection().ExecuteScalarAsync<int>(Queries.AyudaSocial.CreateByRegion,
            new { regionId = regionId, nombre = ayudaSocial.Nombre, descripcion = ayudaSocial.Descripcion, comunaId = ayudaSocial.ComunaId });
    }
}
