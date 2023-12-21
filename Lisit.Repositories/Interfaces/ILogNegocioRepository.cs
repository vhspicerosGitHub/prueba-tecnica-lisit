using Lisit.Models;

namespace Lisit.Repositories.Interfaces {
    public interface ILogNegocioRepository {
        Task<int> Create(LogNegocio log);
        Task<IEnumerable<LogNegocio>> GetAll();
    }
}