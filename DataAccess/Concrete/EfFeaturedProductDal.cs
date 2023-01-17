using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.FeaturedProducts;

namespace DataAccess.Concrete;

public class EfFeaturedProductDal : EfEntityRepositoryBase<FeaturedProduct, FyStoreDbContext>, IFeaturedProductDal
{
    public List<FeaturedProductListDto> GetListWithDetail()
    {
        using var context = new FyStoreDbContext();

        var result = from fp in context.FeaturedProducts
                     join p in context.Products on fp.ProductId equals p.Id
                     join c in context.Categories on p.CategoryId equals c.Id
                     select new FeaturedProductListDto
                     {
                         ProductId = p.Id,
                         ImageUrl = fp.ImageUrl,
                         Name = p.Name,
                         CategoryName = c.Name,
                         Description = p.Description,
                         UnitPrice = p.UnitPrice,
                         UnitsInStock = p.UnitsInStock
                     };

        return result.ToList();
    }
}