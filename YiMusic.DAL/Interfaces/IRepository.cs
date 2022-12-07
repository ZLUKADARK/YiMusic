namespace YiMusic.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(int id, T item);
        Task<T> Delete(int id);
    }
}
