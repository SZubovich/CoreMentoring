using BLL.DTO;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public static class Mapper
    {
        public static IEnumerable<CategoryDTO> ToDTO(this IEnumerable<Categories> categories)
        {
            var categoriesDtoList = new List<CategoryDTO>();

            foreach (var category in categories)
            {
                categoriesDtoList.Add(category.ToDTO());
            }

            return categoriesDtoList;
        }

        public static CategoryDTO ToDTO(this Categories category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }

        public static Categories ToDAL(this CategoryDTO category)
        {
            return new Categories
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }

        public static IEnumerable<ProductDTO> ToDTO(this IEnumerable<Products> products)
        {
            var productsDTOList = new List<ProductDTO>();

            foreach (var product in products)
            {
                productsDTOList.Add(product.ToDTO());
            }

            return productsDTOList;
        }

        public static ProductDTO ToDTO(this Products product)
        {
            return new ProductDTO
            {
                Category = product.Category.CategoryName,
                Discontinued = product.Discontinued,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                Supplier = product.Supplier.CompanyName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder
            };
        }

        public static Products ToDAL(this ProductDTO product, NorthwindContext context)
        {
            return new Products
            {
                Category = context.Categories.First(x => string.Equals($"{x.CategoryName}", $"{product.Category}", StringComparison.OrdinalIgnoreCase)),
                ProductName = product.ProductName,
                UnitsInStock = product.UnitsInStock,
                Supplier = context.Suppliers.First(x => string.Equals($"{x.CompanyName}", $"{product.Supplier}", StringComparison.OrdinalIgnoreCase)),
                QuantityPerUnit = product.QuantityPerUnit,
                UnitsOnOrder = product.UnitsOnOrder,
                Discontinued = product.Discontinued,
                ReorderLevel = product.ReorderLevel,
                UnitPrice = product.UnitPrice,
                ProductId = product.ProductId                
            };
        }
    }
}
