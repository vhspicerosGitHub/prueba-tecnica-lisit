using Lisit.Models.Reportes;

namespace Lisit.Services.Interfaces.Reportes {
    public interface IReportesServices {
        Task<IEnumerable<ReporteDetalle>> GetByear(int año);
        Task<IEnumerable<ReporteDetalle>> GetByUser(int idUsuario);
        Task<IEnumerable<ReporteDetalle>> GetByUserAndYear(int idUsuario, int año);
    }
}