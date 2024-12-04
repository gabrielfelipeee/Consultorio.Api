using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ConsultorioContext _consultorioContext;
        private readonly DbSet<T> _dataset;
        public BaseRepository(ConsultorioContext consultorioContext)
        {
            _consultorioContext = consultorioContext;
            _dataset = consultorioContext.Set<T>();
        }

        public async Task<List<T>> SelectAllAsync()
        {
            var result = await _dataset.ToListAsync();
            return result;
        }
        public async Task<T> SelectByIdAsync(int id)
        {
            var result = await _dataset.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<T> InsertAsync(T item)
        {
            item.CreatedAt = DateTime.UtcNow;
            await _dataset.AddAsync(item);
            await _consultorioContext.SaveChangesAsync();
            return item;
        }
        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result == null)
            {
                return null;
            }
            item.Id = item.Id;
            item.CreatedAt = item.CreatedAt;
            item.UpdatedAt = DateTime.UtcNow;

            _consultorioContext.Entry(result).CurrentValues.SetValues(item);
            await _consultorioContext.SaveChangesAsync();
            return item;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _dataset.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            _dataset.Remove(result);
            await _consultorioContext.SaveChangesAsync();
            return true;
        }
    }
}
