using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces.Interfaces
{
    public interface IRepository<T>
    {
        Task CreateAsync(T newItem);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(int id, T updatedItem);
    }
}
