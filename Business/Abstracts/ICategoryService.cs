using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos.Requests.CategoryDtos;
using Entities.Dtos.Responses.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        Task<IDataResult<GetCategoryByIdResponse>> AddCategories(AddCategoryRequest request);
        Task<IDataResult<GetCategoryByIdResponse>> UpdateCategory(UpdateCategoryRequest request);
        Task<IResult> DeleteCategory(CategoryIdRequest request);
        Task<IDataResult<ICollection<GetAllCategoriesResponse>>> GetAllCategories();
        Task<IDataResult<GetCategoryByIdResponse>> GetCategoryById(CategoryIdRequest request);
        Task<IDataResult<IList<GetAllCategoriesResponse>>> GetCategoriesByIsActiveAsync();
        Task<IDataResult<IList<GetAllCategoriesResponse>>> GetSubCategoriesByCategoryIdAsync(CategoryIdRequest request);
        Task<IDataResult<GetCategoryByIdResponse>> GetParentCategoryByCategoryIdAsync(CategoryIdRequest request);
    }
}
