using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interfaces
{
    public interface IProductService<T> : ICRUDService<T>
    {
        Task<IEnumerable<string>> GetCategoryNames();
        Task<IEnumerable<string>> GetSupplierNames();
    }
}
