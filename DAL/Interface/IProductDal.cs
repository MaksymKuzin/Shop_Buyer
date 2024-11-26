using DTO;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IProductDal
    {
        IEnumerable<ProductDto> GetProductsByCategoryId(int categoryId);
        IEnumerable<ProductDto> SearchProductsByName(string productName);
    }
}
