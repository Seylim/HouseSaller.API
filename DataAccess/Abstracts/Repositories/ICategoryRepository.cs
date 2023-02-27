using DataAccess.Abstracts.BaseRepositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories
{
    public interface ICategoryRepository : IAsyncBaseRepository<Category>, IBaseRepository<Category>
    {
        public Task<IList<Category>> GetCategoriesByIsActiveAsync();
        public Task<IList<Category>> GetSubCategoriesByCategoryIdAsync(int categoryId);
        public Task<Category> GetParentCategoryByCategoryIdAsync(int categoryId);
    }
}
