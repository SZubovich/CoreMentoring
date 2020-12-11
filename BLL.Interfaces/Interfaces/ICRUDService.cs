using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interfaces
{
    public interface ICRUDService<T>
    {
        Task CreateAsync(T newItem);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(int id, T updatedItem);
    }
}
