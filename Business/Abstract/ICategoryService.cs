using Core.Utilities.Results;
using Entities.Dtos.Categories;

namespace Business.Abstract;

public interface ICategoryService
{
    IDataResult<List<CategoryListDto>> GetList();
}