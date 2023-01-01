using Core.DataAccess.Dynamic;
using Core.Utilities.Results;
using Entities.Dtos.Products;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<ProductDto> GetById(int id);

    IDataResult<List<ProductListDto>> GetList();

    IDataResult<List<ProductListDto>> GetListByDynamic(Dynamic dynamic);

    IResult Add(AddProductDto addProductDto);

    IResult Delete(int id);

    IResult Update(UpdateProductDto updateProductDto);
}