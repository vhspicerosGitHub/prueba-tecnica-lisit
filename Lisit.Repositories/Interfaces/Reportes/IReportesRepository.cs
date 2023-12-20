using Lisit.Models.Reportes;

namespace Lisit.Repositories.Interfaces.Reportes {
    public interface IReportesRepository {
        Task<IEnumerable<ReporteDetalle>> GetByear(int año);
        Task<IEnumerable<ReporteDetalle>> GetByUser(int idUsuario);
        Task<IEnumerable<ReporteDetalle>> GetByUserAndYear(int idusuario, int año);
    }
}
