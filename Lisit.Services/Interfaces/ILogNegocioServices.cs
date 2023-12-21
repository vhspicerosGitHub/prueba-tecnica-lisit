using Lisit.Models;

namespace Lisit.Services.Interfaces {
    public interface ILogNegocioServices {
        Task<int> Create(LogNegocio log);
        Task<IEnumerable<LogNegocio>> GetAll();
    }
}