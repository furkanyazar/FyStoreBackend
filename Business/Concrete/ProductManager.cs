using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.Products;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Dynamic;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Products;
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

    [ValidationAspect(typeof(AddProductDtoValidator))]
    [CacheRemoveAspect("Business.Abstract.IProductService.GetList()")]
    public IResult Add(AddProductDto addProductDto)
    {
        Product newProduct = _mapper.Map<Product>(addProductDto);

        IResult result = BusinessRules.Run(CheckIfNameExists(newProduct));
        if (result is not null)
            return result;

        _productDal.Add(newProduct);

        return new SuccessResult();
    }

    [CacheRemoveAspect("Business.Abstract.IProductService.GetList()")]
    public IResult Delete(int id)
    {
        Product product = _productDal.Get(c => c.Id == id);
        if (product is null)
            return new ErrorResult(BusinessMessages.NotFound);

        _productDal.Delete(product);

        return new SuccessResult();
    }

    public IDataResult<ProductDto> GetById(int id)
    {
        Product product = _productDal.Get(c => c.Id == id, include: c => c.Include(c => c.Category));
        ProductDto mappedProduct = _mapper.Map<ProductDto>(product);
        return new SuccessDataResult<ProductDto>(mappedProduct);
    }

    [CacheAspect]
    public IDataResult<List<ProductListDto>> GetList()
    {
        List<Product> products = _productDal.GetList(include: c => c.Include(c => c.Category));
        List<ProductListDto> mappedProducts = _mapper.Map<List<ProductListDto>>(products);
        return new SuccessDataResult<List<ProductListDto>>(mappedProducts);
    }

    public IDataResult<List<ProductListDto>> GetListByDynamic(Dynamic dynamic)
    {
        List<Product> products = _productDal.GetListByDynamic(dynamic, include: c => c.Include(c => c.Category));
        List<ProductListDto> mappedProducts = _mapper.Map<List<ProductListDto>>(products);
        return new SuccessDataResult<List<ProductListDto>>(mappedProducts);
    }

    [ValidationAspect(typeof(UpdateProductDtoValidator))]
    [CacheRemoveAspect("Business.Abstract.IProductService.GetList()")]
    public IResult Update(UpdateProductDto updateProductDto)
    {
        Product productToUpdate = _productDal.Get(c => c.Id == updateProductDto.Id);
        if (productToUpdate is null)
            return new ErrorResult(BusinessMessages.NotFound);

        productToUpdate.Name = updateProductDto.Name;
        productToUpdate.UnitPrice = updateProductDto.UnitPrice;
        productToUpdate.UnitsInStock = updateProductDto.UnitsInStock;

        IResult result = BusinessRules.Run(CheckIfNameExists(productToUpdate));
        if (result is not null)
            return result;

        _productDal.Update(productToUpdate);

        return new SuccessResult();
    }

    private IResult CheckIfNameExists(Product product)
    {
        Product productToCheck = _productDal.Get(c => c.Id != product.Id && c.Name == product.Name);
        return productToCheck is not null
            ? new ErrorResult(BusinessMessages.AlreadyExist)
            : new SuccessResult();
    }
}