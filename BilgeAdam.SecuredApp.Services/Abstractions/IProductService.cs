using BilgeAdam.SecuredApp.Services.Contracts;
using System.Collections.Generic;

namespace BilgeAdam.SecuredApp.Services.Abstractions
{
    public interface IProductService
    {
        ProductDto GetOne(int id);
        IEnumerable<ProductDto> GetMany(int page, int count);
    }
}