using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstracts.Repositories;
using Entities.Concretes;
using Entities.Dtos.Requests.CategoryDtos;
using Entities.Dtos.Responses.CategoryDtos;
using Entities.Dtos.Responses.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetCategoryByIdResponse>> AddCategories(AddCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            category.AddedAt = DateTime.Now;
            if (category.   ParentCategoryId == null)
            {
                await _repository.AddAsync(category);
            }
            else
            {
                var parentCategory = await _repository.GetByIdAsync(category.ParentCategoryId);
                parentCategory.SubCategories.Add(category);
                await _repository.UpdateAsync(parentCategory);
            }
            var addedCategory = _mapper.Map<GetCategoryByIdResponse>(category);
            return new SuccessDataResult<GetCategoryByIdResponse>(Messages.AddedCategory, addedCategory);
        }

        public async Task<IResult> DeleteCategory(CategoryIdRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.DeleteAsync(category.Id);
            return new SuccessResult(Messages.DeletedCategory);
        }

        public async Task<IDataResult<ICollection<GetAllCategoriesResponse>>> GetAllCategories()
        {
            var categories = await _repository.GetAllAsync();
            var gettedCategories = _mapper.Map<ICollection<GetAllCategoriesResponse>>(categories);
            return new SuccessDataResult<ICollection<GetAllCategoriesResponse>>(gettedCategories);
        }

        public async Task<IDataResult<IList<GetAllCategoriesResponse>>> GetCategoriesByIsActiveAsync()
        {
            var categories = await _repository.GetCategoriesByIsActiveAsync();
            var gettedCategories = _mapper.Map<IList<GetAllCategoriesResponse>>(categories);
            return new SuccessDataResult<IList<GetAllCategoriesResponse>>(gettedCategories);
        }

        public async Task<IDataResult<GetCategoryByIdResponse>> GetCategoryById(CategoryIdRequest request)
        {
            var category = _mapper.Map<Category>(request);
            var dbCategory = await _repository.GetByIdAsync(category.Id);
            var gettedCategory = _mapper.Map<GetCategoryByIdResponse>(dbCategory);
            return new SuccessDataResult<GetCategoryByIdResponse>(gettedCategory);
        }

        public async Task<IDataResult<GetCategoryByIdResponse>> GetParentCategoryByCategoryIdAsync(CategoryIdRequest request)
        {
            var category = await _repository.GetParentCategoryByCategoryIdAsync(request.Id);
            var gettedCategory = _mapper.Map<GetCategoryByIdResponse>(category);
            return new SuccessDataResult<GetCategoryByIdResponse>(gettedCategory);
        }

        public async Task<IDataResult<IList<GetAllCategoriesResponse>>> GetSubCategoriesByCategoryIdAsync(CategoryIdRequest request)
        {
            var categories = await _repository.GetSubCategoriesByCategoryIdAsync(request.Id);
            var gettedCategories = _mapper.Map<IList<GetAllCategoriesResponse>>(categories);
            return new SuccessDataResult<IList<GetAllCategoriesResponse>>(gettedCategories);
        }

        public async Task<IDataResult<GetCategoryByIdResponse>> UpdateCategory(UpdateCategoryRequest request)
        {

            var category = await _repository.GetByIdAsync(request.Id);
            if (category != null)
            {
                category = _mapper.Map<Category>(request);
                var updatedCategory = await _repository.UpdateAsync(category);
                var mappedCategory = _mapper.Map<GetCategoryByIdResponse>(updatedCategory);
                return new SuccessDataResult<GetCategoryByIdResponse>(Messages.UpdatedCategory, mappedCategory);
            }
            return new ErrorDataResult<GetCategoryByIdResponse>(Messages.CategoryNotFound, null);
        }
    }
}
