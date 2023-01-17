using Core.Utilities.Results;
using Entities.Dtos.FeaturedProducts;

namespace Business.Abstract;

public interface IFeaturedProductService
{
    IDataResult<List<FeaturedProductListDto>> GetList();
}