using Core.Utilities.Results;
using Entities.Dtos;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<List<ProductGetListDto>> GetList();
}