using DAL.Interfaces.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : IRepository<Categories>
    {
        private readonly NorthwindContext _context;

        public CategoryRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Categories newItem)
        {
            if (!IsExistingCategory(newItem).Result)
            {
                await _context.Categories.AddAsync(newItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var deletedCategory = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            _context.Categories.Remove(deletedCategory);

            await _context.SaveChangesAsync();
        }

        public async Task<Categories> GetAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            return category;
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            var allCategories = await _context.Categories.Include(c => c.Products).OrderBy(cat => cat.CategoryName)
                 .ToListAsync();

            return allCategories;
        }

        public async Task UpdateAsync(int id, Categories updatedItem)
        {
            var existingCategory = await _context.Categories.SingleOrDefaultAsync(cat => cat.CategoryId == id);

            if (existingCategory == null)
            {
                throw new ArgumentException($"Cant update this item");
            }

            if (!string.Equals(existingCategory.CategoryName, updatedItem.CategoryName, StringComparison.OrdinalIgnoreCase)
                || !string.Equals(existingCategory.Description, updatedItem.Description, StringComparison.OrdinalIgnoreCase))
            {
                existingCategory.CategoryName = updatedItem.CategoryName;
                existingCategory.Description = updatedItem.Description;
                existingCategory.Picture = updatedItem.Picture;
            }

            await _context.SaveChangesAsync();
        }

        private async Task<bool> IsExistingCategory(Categories category)
        {
            var categoryChecker = await _context.Categories.FirstOrDefaultAsync(x =>
                string.Equals(x.CategoryName, category.CategoryName, StringComparison.OrdinalIgnoreCase));

            return categoryChecker != null;
        }
    }
}
