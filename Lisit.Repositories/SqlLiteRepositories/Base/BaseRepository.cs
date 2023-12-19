using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Lisit.Repositories.SqlLiteRepositories.Base; 
public abstract class BaseRepository {
    protected readonly IConfiguration _configuration;

    protected BaseRepository(IConfiguration configuration) {
        _configuration = configuration;
    }

    protected SqliteConnection GetConnection() {
        var connString = _configuration.GetConnectionString("DefaultConnection");
        return new SqliteConnection(connString);

    }
}
