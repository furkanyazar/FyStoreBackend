using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    private readonly IMapper _mapper;

    public ProductManager(IProductDal productDal, IMapper mapper)
    {
        _productDal = productDal;
        _mapper = mapper;
    }

    public IDataResult<List<ProductGetListDto>> GetList()
    {
        List<Product> products = _productDal.GetList(include: c => c.Include(c => c.Category));
        List<ProductGetListDto> mappedProducts = _mapper.Map<List<ProductGetListDto>>(products);
        return new SuccessDataResult<List<ProductGetListDto>>(mappedProducts);
    }
}