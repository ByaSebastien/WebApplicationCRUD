using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCRUD.DAL.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetMany(Func<TEntity, bool>? predicate = null);
        public TEntity? GetOne(params object[] ids);
        TEntity? GetOne(Func<TEntity,bool> predicate);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        bool Any(Func<TEntity, bool> predicate);
    }
}
