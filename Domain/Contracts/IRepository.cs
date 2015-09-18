using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmatics.Domain.Contracts
{
    public interface IRepository<T>
    {
        ICollection<T> Get();
        Task<T> Get(int id);
        Task<bool> SaveOrUpdate(T entity);
        void Delete(T entity);
    }
}
