using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.FeaturedProducts;

namespace Business.Concrete;

public class FeaturedProductManager : IFeaturedProductService
{
    private readonly IFeaturedProductDal _featuredProductDal;
    private readonly IMapper _mapper;

    public FeaturedProductManager(IFeaturedProductDal featuredProductDal, IMapper mapper)
    {
        _featuredProductDal = featuredProductDal;
        _mapper = mapper;
    }

    public IDataResult<List<FeaturedProductListDto>> GetList() =>
        new SuccessDataResult<List<FeaturedProductListDto>>(_featuredProductDal.GetListWithDetail());
}