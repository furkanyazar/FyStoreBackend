using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Product : Entity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public virtual Category Category { get; set; }

    public Product()
    {
    }

    public Product(int id, int categoryId, string name, string description, decimal unitPrice, short unitsInStock) : this()
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        UnitsInStock = unitsInStock;
    }
}