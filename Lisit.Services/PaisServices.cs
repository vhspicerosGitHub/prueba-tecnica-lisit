using Lisit.Model;
using Lisit.Repositories.Interfaces.Base;
using Lisit.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Lisit.Services
{
    public class PaisServices : IPaisServices
    {
        private readonly IPaisRepository _repository;
        private readonly ILogger<PaisServices> _logger;

        public PaisServices(IPaisRepository repository, ILogger<PaisServices> logger)
        {
            _repository = repository;
            _logger = logger;

        }

        public async Task<int> Create(Pais obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Pais>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Pais?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(Pais obj)
        {
            await _repository.Update(obj);
        }
    }

}
