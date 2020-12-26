using BilgeAdam.SecuredApp.Data;
using BilgeAdam.SecuredApp.Services.Abstractions;
using BilgeAdam.SecuredApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilgeAdam.SecuredApp.Services.Concretes
{
    internal class ProductService : IProductService
    {
        private readonly NorthwindContext context;

        public ProductService(NorthwindContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductDto> GetMany(int page, int count)
        {
            var offset = (page - 1) * count;
            return context.Products.Select(s => new ProductDto
                                   {
                                       Id = s.ProductID,
                                       Name = s.ProductName,
                                       Price = s.UnitPrice,
                                       Stock = s.UnitsInStock
                                   })
                                   .OrderBy(i => i.Id)
                                   .Skip(offset)
                                   .Take(count)
                                   .ToList();
        }

        public ProductDto GetOne(int id)
        {
            return context.Products.Where(w => w.ProductID == id)
                                   .Select(s => new ProductDto
                                   {
                                       Id = s.ProductID,
                                       Name = s.ProductName,
                                       Price = s.UnitPrice,
                                       Stock = s.UnitsInStock
                                   })
                                   .FirstOrDefault();
        }
    }
}
