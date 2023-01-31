using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Category : Entity
{
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
    }

    public Category(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}