using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryGetListDto>().ReverseMap();
        CreateMap<Product, ProductGetListDto>()
            .ForMember(dest => dest.CategoryName, opt =>
                opt.MapFrom(src => src.Category.Name))
            .ReverseMap();
    }
}