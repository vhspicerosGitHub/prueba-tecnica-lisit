using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Lisit.Services.Interfaces;

namespace Lisit.Services;
public class LogNegocioServices : ILogNegocioServices {
    private readonly ILogNegocioRepository _repository;

    public LogNegocioServices(ILogNegocioRepository repository) {
        _repository = repository;
    }
    public async Task<int> Create(LogNegocio log) {
        return await _repository.Create(log);
    }

    public async Task<IEnumerable<LogNegocio>> GetAll() {
        return await _repository.GetAll();
    }
}
