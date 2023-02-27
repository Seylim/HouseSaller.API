using Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts.BaseRepositories
{
    public interface IBaseRepository<T> where T : class, IEntity
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
        ICollection<T> GetAll();
        T GetById(int id);
    }
}
