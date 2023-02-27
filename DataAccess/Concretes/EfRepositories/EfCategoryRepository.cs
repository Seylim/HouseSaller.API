using DataAccess.Abstracts.Repositories;
using DataAccess.Data;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EfRepositories
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly HouseSallerDbContext _context;

        public EfCategoryRepository(HouseSallerDbContext context)
        {
            _context = context;
        }

        public Category Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            category.IsActive = false;
            Update(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            category.IsActive = false;
            await UpdateAsync(category);
        }

        public ICollection<Category> GetAll()
        {
            var categories = _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).ToList();
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].ParentCategoryId != null)
                {
                    categories[i] = _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).Include(c => c.ParentCategoryId).Where(c => c.Id == categories[i].Id).FirstOrDefault();
                }
            }
            return categories;
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).ToListAsync();
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].ParentCategoryId != null)
                {
                    categories[i] = await _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).Include(c => c.ParentCategoryId).Where(c => c.Id == categories[i].Id).FirstOrDefaultAsync();
                }
            }
            return categories;
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).FirstOrDefault(c => c.Id == id);
            if (category.ParentCategoryId != null)
            {
                category = _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).Include(c => c.ParentCategoryId).Where(c => c.Id == category.Id).FirstOrDefault();
            }
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            var category = await _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).FirstOrDefaultAsync(c => c.Id == id);
            if (category.ParentCategoryId != null)
            {
                category = await _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).Include(c => c.ParentCategoryId).Where(c => c.Id == category.Id).FirstOrDefaultAsync();
            }
            return category;
        }

        public async Task<IList<Category>> GetCategoriesByIsActiveAsync()
        {
            var categories = await _context.Categories.Where(c => c.IsActive == true).Include(c => c.SubCategories).Include(c => c.Ads).ToListAsync();
            for(int i = 0; i < categories.Count; i++)
            {
                if (categories[i].ParentCategoryId != null)
                {
                    Category? category = await _context.Categories.Where(c => c.IsActive == true && c.Id == categories[i].Id).Include(c => c.ParentCategory).Include(c => c.SubCategories).Include(c => c.Ads).FirstOrDefaultAsync();
                    categories[i] = category;
                }
            }
            return categories;
        }

        public async Task<Category> GetParentCategoryByCategoryIdAsync(int categoryId)
        {
            var category = await _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category.ParentCategoryId != null)
            {
                category = await _context.Categories.Include(c => c.ParentCategory).Include(c => c.SubCategories).Include(c => c.Ads).FirstOrDefaultAsync(c => c.Id == category.Id);
            }
            return category.ParentCategory;
        }

        public async Task<IList<Category>> GetSubCategoriesByCategoryIdAsync(int categoryId)
        {
            var category = await _context.Categories.Include(c => c.SubCategories).Include(c => c.Ads).FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category.ParentCategoryId != null)
            {
                category = await _context.Categories.Include(c => c.ParentCategory).Include(c => c.SubCategories).Include(c => c.Ads).FirstOrDefaultAsync(c => c.Id == categoryId);
            }
            return category.SubCategories;
        }

        public Category Update(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
