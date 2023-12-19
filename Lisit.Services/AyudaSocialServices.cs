using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Lisit.Services.Interfaces;

namespace Lisit.Services;
public class AyudaSocialServices : IAyudaSocialServices {
    private readonly IAyudaSocialRepository _repository;
    public AyudaSocialServices(IAyudaSocialRepository repository) {
        _repository = repository;
    }

    public async Task<int> Crear(AyudaSocial ayudaSocial) {
        return await _repository.Crear(ayudaSocial);
    }

    public async Task CrearPorRegion(int RegionId, AyudaSocial ayudaSocial) {
        await _repository.CrearPorRegion(RegionId, ayudaSocial);
    }
}
