using DataAccess.Abstracts.BaseRepositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories
{
    public interface IDistrictRepository : IAsyncBaseRepository<District>, IBaseRepository<District>
    {
        public Task<District> GetDistrictByNameAsync(string name);
        public Task<IList<District>> GetDistrictByCityIdAsync(int cityId);
        public Task<District> GetParentDistrictByDistrictIdAsync(int districtId);
        public Task<IList<District>> GetSubDistrictsByDistrictIdAsync(int districtId);
    }
}
