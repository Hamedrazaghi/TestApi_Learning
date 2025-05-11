using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataLayer.Entitis.Common;

namespace Test.DataLayer.Repository
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {

        IQueryable<TEntity> GetAll();

        Task<TEntity> GetEntityById(long entityId);

        Task AddEntity(TEntity entity);
        void EditEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        Task DeleteEntity(long entityId);
        Task DeletePermenant(long entityId);
        Task SaveChange();
    }
}
