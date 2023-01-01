using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
    }

    public IDataResult<List<CategoryGetListDto>> GetList()
    {
        List<Category> categories = _categoryDal.GetList();
        List<CategoryGetListDto> mappedCategories = _mapper.Map<List<CategoryGetListDto>>(categories);
        return new SuccessDataResult<List<CategoryGetListDto>>(mappedCategories);
    }
}