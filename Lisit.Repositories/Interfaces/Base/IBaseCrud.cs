namespace Lisit.Repositories.Interfaces.Base; 
public interface IBaseCrudRepository<T> {
    Task<IEnumerable<T>> GetAll();

    Task<T?> GetById(int id);

    Task<int> Create(T obj);

    Task Update(T obj);

    Task Delete(int id);
}