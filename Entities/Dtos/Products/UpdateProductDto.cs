namespace Entities.Dtos.Products;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
}