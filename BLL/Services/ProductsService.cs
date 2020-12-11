using BLL.DTO;
using BLL.Interfaces.Interfaces;
using DAL;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductsService : IProductService<ProductDTO>
    {
        private readonly ProductRepository _repository;
        private readonly NorthwindContext _context;

        public ProductsService(NorthwindContext context, IConfiguration configuration)
        {
            _repository = new ProductRepository(context, configuration);
            _context = context;
        }

        public async Task CreateAsync(ProductDTO newItem)
        {
            await _repository.CreateAsync(newItem.ToDAL(_context));
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products.ToDTO();
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            var product = await _repository.GetAsync(id);

            return product.ToDTO();
        }

        public async Task<IEnumerable<string>> GetCategoryNames()
        {
            return await _repository.GetCategoryNames();
        }

        public async Task<IEnumerable<string>> GetSupplierNames()
        {
            return await _repository.GetSupplierNames();
        }

        public async Task UpdateAsync(int id, ProductDTO updatedItem)
        {
            await _repository.UpdateAsync(id, updatedItem.ToDAL(_context));
        }
    }
}
