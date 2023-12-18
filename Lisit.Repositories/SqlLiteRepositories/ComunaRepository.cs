using Lisit.Model;
using Lisit.Repositories.Interfaces.Base;

namespace Lisit.Repositories.SqlLiteRepositories;

public class ComunaRepository : IComunaRepository
{
    public Task<int> Create(Pais obj)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Pais Obj)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Pais>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Pais?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Pais obj)
    {
        throw new NotImplementedException();
    }
}
