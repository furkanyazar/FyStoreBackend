using Core.Entities.Abstract;

namespace Entities.Dtos.Products;

public class UpdateProductDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
}