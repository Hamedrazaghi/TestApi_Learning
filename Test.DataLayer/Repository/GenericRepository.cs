/*
using Test.DataLayer.Entitis.Common;*/

using Test.DataLayer.Repository;
using Test.DataLayer.Entitis.Common;
using Test.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Test.DataLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region constructor
        private readonly TestDbContext _context;
        private readonly DbSet<TEntity> _dbset;
        public GenericRepository(TestDbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
        #endregion

        public IQueryable<TEntity> GetAll()
        {
            return _dbset.AsQueryable();
        }

        public async Task<TEntity> GetEntityById(long entityId)
        {
            return await _dbset.AsQueryable().FirstOrDefaultAsync(s=> s.Id == entityId);
        }


        public async Task AddEntity(TEntity entity)
        { 
            entity.CreateDate = DateTime.Now;
            await _dbset.AddAsync(entity);
        }

        public void EditEntity(TEntity entity)
        {
            entity.LastUpdate = DateTime.Now;
            _dbset.Update(entity);
        }

        public void DeleteEntity(TEntity entity)
        {
            entity.IsDeleted = true;
            EditEntity(entity);
        }


        public async Task DeleteEntity(long entityId)
        { 
            TEntity entity = await GetEntityById(entityId);
            if (entity != null) 
            {
                DeleteEntity(entity);
            }
        }

        public void DeletePermenant(TEntity entity)
        {
            _dbset.Remove(entity);
        }
        public async Task DeletePermenant(long entityId)
        {
            TEntity entity = await GetEntityById(entityId);
            if(entity != null)
            {
                DeletePermenant(entity);
            }
        }


        public async Task SaveChange()
        { 
            await _context.SaveChangesAsync();
        }


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }

}
