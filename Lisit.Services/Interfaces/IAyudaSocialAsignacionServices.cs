using Lisit.Models;

namespace Lisit.Services.Interfaces {
    public interface IAyudaSocialAsignacionServices {
        Task<int> Crear(AyudaSocialAsignacion ayudaSocialAsignacion);

    }
}
