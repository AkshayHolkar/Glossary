using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glossaries.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        bool IsExist(int id);
    }
}
