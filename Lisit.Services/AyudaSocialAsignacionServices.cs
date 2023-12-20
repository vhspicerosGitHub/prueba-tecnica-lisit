using Lisit.Common;
using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Lisit.Services.Interfaces;

namespace Lisit.Services {
    public class AyudaSocialAsignacionServices : IAyudaSocialAsignacionServices {
        public readonly IAyudaSocialAsignacionRepository _repository;
        public AyudaSocialAsignacionServices(IAyudaSocialAsignacionRepository repository) {
            _repository = repository;
        }

        public async Task<int> Crear(AyudaSocialAsignacion asignacion) {

            var a = await _repository.ObtieneAsignaciones(asignacion.ResidenteId, asignacion.AyudaSocialId, asignacion.AñoAsignacion);
            if (!a.Any()) {
                throw new BusinessException("Ya tiene una asignacion el mismo año");
            }

            return await _repository.Create(asignacion);
        }
    }
}
