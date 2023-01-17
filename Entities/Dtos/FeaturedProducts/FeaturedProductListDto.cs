using Core.Entities.Abstract;

namespace Entities.Dtos.FeaturedProducts;

public class FeaturedProductListDto : IDto
{
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
}