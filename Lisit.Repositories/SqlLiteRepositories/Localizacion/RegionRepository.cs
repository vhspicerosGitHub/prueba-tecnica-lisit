using Dapper;
using Lisit.Models.Localizacion;
using Lisit.Repositories.Interfaces.Localizacion;
using Lisit.Repositories.SqlLiteRepositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using queries = Lisit.Repositories.SqlLiteRepositories.Localizacion.Queries.Region;

namespace Lisit.Repositories.SqlLiteRepositories.Localizacion;
public class RegionRepository : BaseRepository, IRegionRepository {

    private readonly ILogger<BaseRepository> _logger;


    public RegionRepository(IConfiguration configuration, ILogger<PaisRepository> logger) : base(configuration) {
        _logger = logger;
    }

    public async Task<int> Create(Region obj) {
        return await GetConnection().ExecuteScalarAsync<int>(queries.Create, new { nombre = obj.Nombre, paisId = obj.PaisId });
    }

    public async Task Delete(int id) {
        _ = await GetConnection().ExecuteAsync(queries.Delete, new { id });
    }

    public async Task<IEnumerable<Region>> GetAll() {
        return await GetConnection().QueryAsync<Region>(queries.GetAll);
    }

    public async Task<Region?> GetById(int id) {
        return await GetConnection().QueryFirstOrDefaultAsync<Region>(queries.GetById, new { id });
    }

    public async Task Update(Region obj) {
        _ = await GetConnection().ExecuteAsync(queries.Update,
                new { id = obj.Id, nombre = obj.Nombre, paisId = obj.PaisId });
    }
}
