using Lisit.Models;
using Lisit.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Lisit.Repositories.SqlLiteRepositories;
public class AyudaSocialAsignacionRepository : Base.BaseRepository, IAyudaSocialAsignacionRepository {
    public AyudaSocialAsignacionRepository(IConfiguration configuration) : base(configuration) {
    }

    public Task<int> Create(AyudaSocialAsignacion ayudaSocialAsignacion) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AyudaSocialAsignacion>> ObtieneAsignaciones(int idusuario, int idAyudaSocial, int año) {
        throw new NotImplementedException();
    }
}
