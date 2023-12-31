﻿using Dapper;
using Lisit.Models.Localizacion;
using Lisit.Repositories.Interfaces.Localizacion;
using Lisit.Repositories.SqlLiteRepositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using queries = Lisit.Repositories.SqlLiteRepositories.Localizacion.Queries.Pais;

namespace Lisit.Repositories.SqlLiteRepositories.Localizacion;

public class PaisRepository : BaseRepository, IPaisRepository {

    private readonly ILogger<BaseRepository> _logger;


    public PaisRepository(IConfiguration configuration, ILogger<PaisRepository> logger) : base(configuration) {
        _logger = logger;
    }

    public async Task<int> Create(Pais obj) {
        return await GetConnection().ExecuteScalarAsync<int>(queries.Create,
            new { nombre = obj.Nombre });
    }

    public async Task Delete(int id) {
        _ = await GetConnection().ExecuteAsync(queries.Delete, new { id });
    }

    public async Task<IEnumerable<Pais>> GetAll() {
        return await GetConnection().QueryAsync<Pais>(queries.GetAll);
    }

    public async Task<Pais?> GetById(int id) {
        return await GetConnection().QueryFirstOrDefaultAsync<Pais>(queries.GetById, new { id });
    }

    public async Task Update(Pais obj) {
        _ = await GetConnection().ExecuteAsync(queries.Update,
                new { id = obj.Id, nombre = obj.Nombre });
    }
}
