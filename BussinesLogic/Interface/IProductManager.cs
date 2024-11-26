using DTO;
using System.Collections.Generic;

namespace BussinesLogic.Interface
{
    public interface IProductManager
    {
        IEnumerable<ProductDto> GetAllProducts();
        IEnumerable<ProductDto> GetProductsByCategory(int categoryId);
        IEnumerable<ProductDto> SearchProductsByName(string productName);
    }
}
