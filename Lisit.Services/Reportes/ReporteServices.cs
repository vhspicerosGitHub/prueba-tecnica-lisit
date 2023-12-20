using Lisit.Models.Reportes;
using Lisit.Repositories.Interfaces.Reportes;
using Lisit.Services.Interfaces.Reportes;

namespace Lisit.Services.Reportes;
public class ReportesServices : IReportesServices {
    private readonly IReportesRepository _repository;

    public ReportesServices(IReportesRepository repository) {
        _repository = repository;
    }

    public async Task<IEnumerable<ReporteDetalle>> GetByUser(int idUsuario) {
        return await _repository.GetByUser(idUsuario);
    }

    public async Task<IEnumerable<ReporteDetalle>> GetByUserAndYear(int idUsuario, int año) {
        return await _repository.GetByUserAndYear(idUsuario, año);
    }

    public async Task<IEnumerable<ReporteDetalle>> GetByear(int año) {
        return await _repository.GetByear(año);
    }
}
