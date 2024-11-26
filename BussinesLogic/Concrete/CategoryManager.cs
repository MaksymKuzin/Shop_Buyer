using BussinesLogic.Interface;
using DAL.Interface;
using DTO;
using System.Collections.Generic;

namespace BussinesLogic.Concrete
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return _categoryDal.GetAllCategories();
        }
    }
}
