using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.Products;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
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

    [LogAspect(typeof(FileLogger))]
    [ValidationAspect(typeof(AddProductDtoValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(AddProductDto addProductDto)
    {
        Product newProduct = _mapper.Map<Product>(addProductDto);

        IResult result = BusinessRules.Run(CheckIfNameExists(newProduct));
        if (result is not null)
            return result;

        _productDal.Add(newProduct);

        return new SuccessResult();
    }

    [LogAspect(typeof(FileLogger))]
    [CacheRemoveAspect("IProductService.Get")]
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
    public IDataResult<List<ProductListDto>> GetList() =>
        new SuccessDataResult<List<ProductListDto>>(_productDal.GetListWithCategory());

    public IDataResult<List<ProductListDto>> GetListByDynamic(Dynamic dynamic)
    {
        List<Product> products = _productDal.GetListByDynamic(dynamic, include: c => c.Include(c => c.Category));
        List<ProductListDto> mappedProducts = _mapper.Map<List<ProductListDto>>(products);
        return new SuccessDataResult<List<ProductListDto>>(mappedProducts);
    }

    [LogAspect(typeof(FileLogger))]
    [ValidationAspect(typeof(UpdateProductDtoValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(UpdateProductDto updateProductDto)
    {
        Product productToUpdate = _productDal.Get(c => c.Id == updateProductDto.Id);
        if (productToUpdate is null)
            return new ErrorResult(BusinessMessages.NotFound);

        productToUpdate.Name = updateProductDto.Name;
        productToUpdate.Description = updateProductDto.Description;
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