using Lisit.Models.Localizacion;
using Lisit.Repositories.Interfaces.Localizacion;
using Lisit.Services.Interfaces.Localizacion;
using Microsoft.Extensions.Logging;

namespace Lisit.Services.Localizacion;
public class RegionServices : IRegionServices {

    private readonly IRegionRepository _repository;
    private readonly ILogger<RegionServices> _logger;

    public RegionServices(IRegionRepository repository, ILogger<RegionServices> logger) {
        _repository = repository;
        _logger = logger;

    }
    public async Task<int> Create(Region obj) {
        return await _repository.Create(obj);
    }

    public async Task Delete(int id) {
        await _repository.Delete(id);
    }

    public async Task<IEnumerable<Region>> GetAll() {
        return await _repository.GetAll();
    }

    public async Task<Region?> GetById(int id) {
        return await _repository.GetById(id);
    }

    public async Task Update(Region obj) {
        await _repository.Update(obj);
    }
}

