using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.FeaturedProducts;

namespace DataAccess.Abstract;

public interface IFeaturedProductDal : IEntityRepository<FeaturedProduct>
{
    List<FeaturedProductListDto> GetListWithDetail();
}