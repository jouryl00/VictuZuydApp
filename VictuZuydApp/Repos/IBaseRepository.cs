using VictuZuydApp.Models;

namespace VictuZuydApp.Repos
{
    public interface IBaseRepository<T> where T : TableData
    {
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}