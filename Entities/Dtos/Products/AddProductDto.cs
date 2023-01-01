namespace Entities.Dtos.Products;

public class AddProductDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
}