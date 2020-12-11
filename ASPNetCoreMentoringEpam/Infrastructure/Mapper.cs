using ASPNetCoreMentoringEpam.ViewModels;
using BLL.DTO;
using System.Collections.Generic;

namespace ASPNetCoreMentoringEpam.Infrastructure
{
    public static class Mapper
    {
        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<ProductDTO> products)
        {
            var productsList = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsList.Add(product.ToView());
            }

            return productsList;
        }

        public static ProductViewModel ToView(this ProductDTO product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                Category = product.Category,
                Discontinued = product.Discontinued,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                Supplier = product.Supplier,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder
            };
        }

        public static ProductDTO ToBLL(this ProductViewModel product)
        {
            return new ProductDTO
            {
                ProductId = product.ProductId,
                Discontinued = product.Discontinued,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                Supplier = product.Supplier,
                Category = product.Category
            };
        }

        public static IEnumerable<CategoryViewModel> ToView(this IEnumerable<CategoryDTO> categories)
        {
            var categoriesDtoList = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                categoriesDtoList.Add(category.ToView());
            }

            return categoriesDtoList;
        }

        public static CategoryViewModel ToView(this CategoryDTO category)
        {
            return new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }

        public static CategoryDTO ToBLL(this CategoryViewModel category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }
    }
}
