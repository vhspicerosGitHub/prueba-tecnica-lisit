namespace Lisit.Services.Interfaces.Base
{
    public interface IBaseCrudServices<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(int id);

        Task<int> Create(T obj);

        Task Update(T obj);

        Task Delete(int Obj);
    }
}