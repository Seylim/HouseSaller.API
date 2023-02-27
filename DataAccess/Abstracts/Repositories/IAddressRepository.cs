using DataAccess.Abstracts.BaseRepositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories
{
    public interface IAddressRepository : IAsyncBaseRepository<Address>, IBaseRepository<Address>
    {
        public Task<IList<Address>> GetAddressesByIsActiveAsync();
    }
}
