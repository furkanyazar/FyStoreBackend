using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Categories;
using Entities.Dtos.Products;

namespace Business.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryListDto>().ReverseMap();
        CreateMap<Product, ProductListDto>()
            .ForMember(dest => dest.CategoryName, opt =>
                opt.MapFrom(src => src.Category.Name))
            .ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, AddProductDto>().ReverseMap();
    }
}