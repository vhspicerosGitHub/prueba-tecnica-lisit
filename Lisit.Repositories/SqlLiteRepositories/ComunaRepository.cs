using Dapper;
using Lisit.Model;
using Lisit.Repositories.Base;
using Lisit.Repositories.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using queries = Lisit.Repositories.SqlLiteRepositories.Queries.Comuna;

namespace Lisit.Repositories.SqlLiteRepositories;

public class ComunaRepository : BaseRepository, IComunaRepository
{
    private readonly ILogger<BaseRepository> _logger;


    public ComunaRepository(IConfiguration configuration, ILogger<PaisRepository> logger) : base(configuration)
    {
        this._logger = logger;
    }

    public async Task<int> Create(Comuna obj)
    {
        return await GetConnection().ExecuteScalarAsync<int>(queries.Create, new { nombre = obj.Nombre, regionId = obj.RegionId });
    }

    public async Task Delete(int id)
    {
        _ = await GetConnection().ExecuteAsync(queries.Delete, new { id });
    }

    public async Task<IEnumerable<Comuna>> GetAll()
    {
        return await GetConnection().QueryAsync<Comuna>(queries.GetAll);
    }

    public async Task<Comuna?> GetById(int id)
    {
        return await GetConnection().QueryFirstOrDefaultAsync<Comuna>(queries.GetById, new { id });
    }

    public async Task Update(Comuna obj)
    {
        _ = await GetConnection().ExecuteAsync(queries.Update,
        new { id = obj.Id, nombre = obj.Nombre, regionId = obj.RegionId });
    }
}
