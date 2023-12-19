using Lisit.Models;

namespace Lisit.Services.Interfaces {
    public interface IAyudaSocialServices{
        Task<int> Crear(AyudaSocial ayudaSocial);

        Task CrearPorRegion(int RegionId, AyudaSocial ayudaSocial);
    }
}
