using Core.Utilities.Results;
using Entities.Dtos;

namespace Business.Abstract;

public interface ICategoryService
{
    IDataResult<List<CategoryGetListDto>> GetList();
}