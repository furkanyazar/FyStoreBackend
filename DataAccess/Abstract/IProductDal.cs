using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Products;

namespace DataAccess.Abstract;

public interface IProductDal : IEntityRepository<Product>
{
    List<ProductListDto> GetListWithCategory();
}