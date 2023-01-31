using Core.Entities.Abstract;

namespace Entities.Concrete;

public class FeaturedProduct : Entity
{
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }

    public virtual Product Product { get; set; }

    public FeaturedProduct()
    {
    }

    public FeaturedProduct(int id, int productId, string ımageUrl) : this()
    {
        Id = id;
        ProductId = productId;
        ImageUrl = ımageUrl;
    }
}