namespace YiMusic.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Update(int id, T item);
        Task<bool> Delete(int id);
    }
}
