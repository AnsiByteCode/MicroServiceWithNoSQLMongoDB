
namespace Core.Repository
{
    #region Using
    using Core.Entities;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// Repository of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Core.Repository.IRepository{T}" />
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The collection
        /// </summary>
        private MongoCollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(UnitOfWork<T> dbContext)
        {
            collection = dbContext.collection;
        }

        /// <summary>
        /// Gets the specified query expression.
        /// </summary>
        /// <param name="queryExpression">The query expression.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T Get(Expression<Func<T, string>> queryExpression, string id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            return collection.FindOne(query);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            MongoCursor<T> cursor = collection.FindAll();
            return cursor.AsQueryable<T>();
        }

        /// <summary>
        /// Generic add method to insert enities to collection
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            collection.Insert(entity);
        }

        /// <summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        public void Delete(IMongoQuery filterParam)
        {
            collection.Remove(filterParam);
        }

        /// <summary>
        /// Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        /// <param name="entity">The entity.</param>
        public void Update(IMongoQuery filterParam, T entity)
        {
            //var query = Query<T>.Matches(queryExpression, new BsonRegularExpression("/^" + id + "$/i"));
            collection.Update(filterParam, Update<T>.Replace(entity));
        }

        /// <summary>
        /// Filters the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public IQueryable<T> Filter(Dictionary<string, string> filterParams) {
            var queries = new List<IMongoQuery>();
            if (filterParams.Count > 0)
            {
                foreach (var item in filterParams)
                {
                  queries.Add(Query.EQ(item.Key, item.Value));
                }    
            }
            MongoCursor<T> cursor = collection.Find(Query.And(queries));
            return cursor.AsQueryable<T>();
        }

        /// <summary>
        /// Filters the with query.
        /// </summary>
        /// <param name="filterParams">The filter parameters.</param>
        /// <returns></returns>
        public IQueryable<T> FilterWithQuery(IMongoQuery filterParams)
        {
            MongoCursor<T> cursor = collection.Find(filterParams);
            return cursor.AsQueryable<T>();
        }
    }
}
