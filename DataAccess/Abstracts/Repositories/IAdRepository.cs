using DataAccess.Abstracts.BaseRepositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories
{
    public interface IAdRepository : IAsyncBaseRepository<Ad>, IBaseRepository<Ad>
    {
        public Task<IList<Ad>> GetAdsByIsActiveAsync();
        public Task<IList<Ad>> GetAdsByCategoryIdAsync(int categoryId);
        public Task<IList<Ad>> GetAdsByPriceAsync(int minPrice, int maxPrice);
    }
}
