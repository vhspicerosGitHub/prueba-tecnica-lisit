using Dapper;
using Lisit.Models.Reportes;
using Lisit.Repositories.Interfaces.Reportes;
using Microsoft.Extensions.Configuration;

namespace Lisit.Repositories.SqlLiteRepositories.Reportes {
    public class ReportesRepository : Base.BaseRepository, IReportesRepository {
        public ReportesRepository(IConfiguration configuration) : base(configuration) {
        }

        public async Task<IEnumerable<ReporteDetalle>> GetByUser(int idUsuario) {
            return await GetConnection().QueryAsync<ReporteDetalle>(Queries.Reportes.GetByUser, new { idUsuario });
        }

        public async Task<IEnumerable<ReporteDetalle>> GetByUserAndYear(int idUsuario, int año) {
            return await GetConnection().QueryAsync<ReporteDetalle>(Queries.Reportes.GetByUserAndYear, new { idUsuario, year= año });
        }

        public async Task<IEnumerable<ReporteDetalle>> GetByear(int año) {
            return await GetConnection().QueryAsync<ReporteDetalle>(Queries.Reportes.GetByYear, new { año ,year=año});
        }
    }
}
