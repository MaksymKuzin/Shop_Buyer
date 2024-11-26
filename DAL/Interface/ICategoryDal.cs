using DTO;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface ICategoryDal
    {
        IEnumerable<CategoryDto> GetAllCategories();
    }
}
