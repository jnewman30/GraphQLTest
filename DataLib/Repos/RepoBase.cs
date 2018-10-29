using System;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DataLib.Repos
{
    public abstract class RepoBase<TEntity, TKey> : IRepo<TEntity, TKey>
        where TEntity : class
    {
        protected RepoBase(IMasterDb masterDb)
        {
            MasterDb = masterDb;
        }

        protected IMasterDb MasterDb { get; }

        public IEnumerable<TEntity> GetAll()
        {
            using (var conn = MasterDb.GetConnection())
            {
                return conn.GetAll<TEntity>();
            }
        }

        public TEntity Create(TEntity item)
        {
            using (var conn = MasterDb.GetConnection())
            {
                var id = conn.Insert(item);
                return item;
            }
        }

        public TEntity GetById(TKey id)
        {
            using (var conn = MasterDb.GetConnection())
            {
                var tableName = GetTableName<TEntity>();
                return conn.QueryFirstOrDefault<TEntity>($"SELECT * FROM {tableName} WHERE Id = @id", new { id });
            }
        }

        protected string GetTableName<T>()
            where T : class
        {
            return GetTableName(typeof(T));
        }

        protected string GetTableName(Type t)
        {
            var tableAttr = (TableAttribute) Attribute.GetCustomAttribute(t, typeof(TableAttribute));
            return tableAttr?.Name;
        }
    }
}