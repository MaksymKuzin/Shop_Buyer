using DTO;
using System.Collections.Generic;

namespace BussinesLogic.Interface
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryDto> GetCategories();
    }
}
