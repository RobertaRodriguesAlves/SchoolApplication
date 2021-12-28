using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAll();
        Task Create(TEntity entity);
        Task Update(string id, TEntity entity);
    }
}
