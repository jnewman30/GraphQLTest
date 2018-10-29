using System.Collections.Generic;

namespace DataLib.Repos
{
    public interface IRepo<TEntity, TKey>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Create(TEntity item);

        TEntity GetById(TKey id);
    }
}