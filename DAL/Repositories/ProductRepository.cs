using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository<Products>
    {
        private readonly NorthwindContext _context;
        private readonly IConfiguration _configuration;
        private const int MaximumProductsCount = 0;

        public ProductRepository(NorthwindContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task CreateAsync(Products newItem)
        {
            if (!IsExistingProduct(newItem).Result)
            {
                await _context.Products.AddAsync(newItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var deletedProduct = await _context.Products.FirstOrDefaultAsync(x => x.CategoryId == id);
            _context.Products.Remove(deletedProduct);

            await _context.SaveChangesAsync();
        }

        public async Task<Products> GetAsync(int id)
        {
            var product = await _context
                .Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(x => x.ProductId == id);

            return product;
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            IQueryable<Products> products = _context.Products;

            var maximumProductsCount = MaximumProductsCount;

            if (int.TryParse(_configuration.GetSection("MaximumProductsCount").Value, out maximumProductsCount))
            {
                if (maximumProductsCount > 0)
                {
                    products = products.Take(maximumProductsCount);
                }
            }

            return await products.Include(x => x.Category).Include(x => x.Supplier).ToListAsync();
        }

        public async Task UpdateAsync(int id, Products updatedItem)
        {
            var existingProduct = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);

            if (existingProduct != null)
            {
                existingProduct.Category = await _context.Categories.FirstAsync(x =>
                    string.Equals($"{x.CategoryName}", $"{updatedItem.Category.CategoryName}", StringComparison.OrdinalIgnoreCase));
                existingProduct.Discontinued = updatedItem.Discontinued;
                existingProduct.QuantityPerUnit = updatedItem.QuantityPerUnit;
                existingProduct.ReorderLevel = updatedItem.ReorderLevel;
                existingProduct.Supplier = await _context.Suppliers.FirstAsync(x =>
                    string.Equals($"{x.CompanyName}", $"{updatedItem.Supplier.CompanyName}", StringComparison.OrdinalIgnoreCase));
                existingProduct.UnitPrice = updatedItem.UnitPrice;
                existingProduct.UnitsInStock = updatedItem.UnitsInStock;
                existingProduct.UnitsOnOrder = updatedItem.UnitsOnOrder;
                existingProduct.ProductName = updatedItem.ProductName;

                await _context.SaveChangesAsync();
            }
        }

        private async Task<bool> IsExistingProduct(Products product)
        {
            var productChecker = await _context.Products.FirstOrDefaultAsync(x =>
                string.Equals(x.ProductName, product.ProductName, StringComparison.OrdinalIgnoreCase));

            return productChecker != null;
        }

        public async Task<IEnumerable<string>> GetCategoryNames()
        {
            return await _context.Categories.Select(x => x.CategoryName).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetSupplierNames()
        {
            return await _context.Suppliers.Select(x => x.CompanyName).ToListAsync();
        }
    }
}
