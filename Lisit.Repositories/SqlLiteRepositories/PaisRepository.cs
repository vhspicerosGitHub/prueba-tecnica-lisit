using Dapper;
using Lisit.Model;
using Lisit.Repositories.Base;
using Lisit.Repositories.Interfaces.Base;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Lisit.Repositories.SqlLiteRepositories;

public class PaisRepository : BaseRepository, IPaisRepository
{

    private readonly ILogger<BaseRepository> _logger;

    public PaisRepository(IConfiguration configuration, ILogger<PaisRepository> logger) : base(configuration)
    {
        this._logger = logger;
    }

    public Task<int> Create(Pais obj)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Pais Obj)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Pais>> GetAll()
    {
        return await GetConnection().QueryAsync<Pais>(PaisQueries.GetAll);
    }

    public Task<Pais?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Pais obj)
    {
        throw new NotImplementedException();
    }
}
