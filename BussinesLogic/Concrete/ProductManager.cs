using BussinesLogic.Interface;
using DAL.Interface;
using DTO;
using System.Collections.Generic;

namespace BussinesLogic.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IEnumerable<ProductDto> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetProductsByCategoryId(categoryId);
        }

        public IEnumerable<ProductDto> SearchProductsByName(string productName)
        {
            return _productDal.SearchProductsByName(productName);
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }
    }
}
