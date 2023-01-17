using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;

namespace DataAccess.Concrete;

public class EfProductDal : EfEntityRepositoryBase<Product, FyStoreDbContext>, IProductDal
{
    public List<ProductListDto> GetListWithCategory()
    {
        using var context = new FyStoreDbContext();

        var result = from p in context.Products
                     join c in context.Categories on p.CategoryId equals c.Id
                     select new ProductListDto
                     {
                         Id = p.Id,
                         Name = p.Name,
                         Description = p.Description,
                         UnitPrice = p.UnitPrice,
                         UnitsInStock = p.UnitsInStock,
                         CategoryName = c.Name
                     };

        return result.ToList();
    }
}