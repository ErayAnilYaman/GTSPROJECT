
namespace Data.Concrete.Base
{
    #region usings
    using Data.Abstract.Base;
    using Data.Db;
    using Data.Models.Abstract;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var db = new ThesesContext())
            {
                var addedEntity = db.Entry(entity);
                addedEntity.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var db = new ThesesContext())
            {
                var deletedEntity = db.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var db = new ThesesContext())
            {
                var result = (filter != null) ? db.Set<TEntity>().SingleOrDefault(filter): null;
                return result;
            }
        }

        public  List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new ThesesContext())
            {
                return (filter == null) ? db.Set<TEntity>().ToList(): db.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Update(TEntity entity)
        {
            using (var db = new ThesesContext())
            {
                var updatedEntity = db.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
