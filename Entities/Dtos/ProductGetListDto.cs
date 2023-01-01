namespace Entities.Dtos;

public class ProductGetListDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
}