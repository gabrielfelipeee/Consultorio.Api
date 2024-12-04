using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> SelectAllAsync();
        Task<T> SelectByIdAsync(int id);
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
    }
}
