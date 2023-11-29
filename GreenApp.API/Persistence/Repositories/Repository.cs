using GreenCollege.API.Data;
using GreenCollege.API.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace GreenCollege.API.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly GreenCollegeDbContext _context;
        internal readonly DbSet<TEntity> _dbSet;

        public Repository(GreenCollegeDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                Update(e);
            }
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
