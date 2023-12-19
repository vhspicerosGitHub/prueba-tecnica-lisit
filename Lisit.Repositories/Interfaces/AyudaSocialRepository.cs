using Lisit.Models;

namespace Lisit.Repositories.Interfaces;
public interface IAyudaSocialRepository {

    Task<int> Crear(AyudaSocial ayudaSocial);

    Task CrearPorRegion(int RegionId, AyudaSocial ayudaSocial);

}
