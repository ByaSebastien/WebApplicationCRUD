using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCRUD.DAL.Context;

namespace WebApplicationCRUD.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public DbContext _gameDbContext { get; private set; }
        public DbSet<TEntity> _entities { get; private set; }
        public BaseRepository(DbContext dbContext)
        {
            _gameDbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetMany(Func<TEntity, bool>? predicate)
        {
            if (predicate is null)
                return _entities;
            return _entities.Where(predicate);
        }
        public TEntity? GetOne(params object[] ids)
        {
            return _entities.Find(ids);
        }
        public TEntity? GetOne(Func<TEntity, bool> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }
        public TEntity Insert(TEntity entity)
        {

            TEntity result = _entities.Add(entity).Entity;
            _gameDbContext.SaveChanges();
            return result;
        }
        public TEntity Update(TEntity entity)
        {
            TEntity result = _entities.Update(entity).Entity;
            _gameDbContext.SaveChanges();
            return result;
        }
        public TEntity Delete(TEntity entity)
        {
            TEntity result = _entities.Remove(entity).Entity;
            _gameDbContext.SaveChanges();
            return result;
        }
        public bool Any(Func<TEntity, bool> predicate)
        {
            return _entities.Any(predicate);
        }
    }
}
