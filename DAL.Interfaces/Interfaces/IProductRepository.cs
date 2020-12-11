using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces.Interfaces
{
    public interface IProductRepository<T> : IRepository<T>
    {
        Task<IEnumerable<string>> GetCategoryNames();
        Task<IEnumerable<string>> GetSupplierNames();
    }
}
