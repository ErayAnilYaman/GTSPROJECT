

namespace Data.Abstract.Base
{
    #region usings
    using Data.Models.Abstract;
    using System.Linq.Expressions;
    #endregion
    public interface IEntityRepositoryBase<TEntity>
        where TEntity : class ,IEntity , new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity,bool >> filter = null);
        TEntity Get(Expression<Func<TEntity , bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
