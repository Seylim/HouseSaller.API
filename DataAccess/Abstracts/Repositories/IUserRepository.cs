using DataAccess.Abstracts.BaseRepositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.Repositories
{
    public interface IUserRepository : IBaseRepository<User>, IAsyncBaseRepository<User>
    {
        public Task<IList<OperationClaim>> GetOperationClaims(User user);
        public Task<User> GetUserByMail(string email);
    }
}
