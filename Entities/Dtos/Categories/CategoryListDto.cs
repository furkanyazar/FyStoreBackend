using Core.Entities.Abstract;

namespace Entities.Dtos.Categories;

public class CategoryListDto : IDto
{
    public int Id { get; set; }

    public string Name { get; set; }
}