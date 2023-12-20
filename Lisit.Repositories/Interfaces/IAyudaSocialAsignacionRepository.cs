using Lisit.Models;

namespace Lisit.Repositories.Interfaces {
    public interface IAyudaSocialAsignacionRepository {
        Task<int> Create(AyudaSocialAsignacion ayudaSocialAsignacion);

        Task<IEnumerable<AyudaSocialAsignacion>> ObtieneAsignaciones(int idusuario, int idAyudaSocial, int año);
    }
}
