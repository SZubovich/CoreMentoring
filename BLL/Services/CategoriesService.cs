using DAL;
using DAL.Repositories;
using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Interfaces;

namespace BLL.Services
{
    public class CategoriesService : ICRUDService<CategoryDTO>
    {
        CategoryRepository _repository;

        public CategoriesService(NorthwindContext context)
        {
            _repository = new CategoryRepository(context);
        }

        public async Task CreateAsync(CategoryDTO newItem)
        {
            await _repository.CreateAsync(newItem.ToDAL());
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();

            return categories.ToDTO();
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            if (id > 0)
            {
                var category = await _repository.GetAsync(id);
                return category.ToDTO();
            }

            return null;
        }

        public async Task UpdateAsync(int id, CategoryDTO updatedItem)
        {
            if (id > 0)
            {
                await _repository.UpdateAsync(id, updatedItem.ToDAL());
            }
        }
    }
}
