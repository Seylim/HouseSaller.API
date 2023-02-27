using Core.Entities.Concrete;
using DataAccess.Abstracts.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories
{
    public interface IPhotoRepository : IAsyncBaseRepository<Photo>, IBaseRepository<Photo>
    {
        Task<IList<Photo>> GetPhotosByAdId(int adId);
    }
}
