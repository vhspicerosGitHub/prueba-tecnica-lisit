using Lisit.Model;
using Lisit.Repositories.Interfaces.Base;
using Lisit.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Lisit.Services
{
    public class ComunaServices : IComunaServices
    {
        private readonly IComunaRepository _repository;
        private readonly ILogger<ComunaServices> _logger;

        
        public ComunaServices(IComunaRepository repository, ILogger<ComunaServices> logger)
        {
            _repository = repository;
            _logger = logger;

        }
        public async Task<int> Create(Comuna obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Comuna>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Comuna?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(Comuna obj)
        {
            await _repository.Update(obj);
        }
    }
}