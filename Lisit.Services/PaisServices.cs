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

        public Task<int> Create(Pais obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Pais Obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pais>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Pais?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public Task Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }

}
