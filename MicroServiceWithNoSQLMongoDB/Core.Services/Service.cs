namespace Core.Services
{
    #region Using
    using MongoDB.Driver;
    using Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// TEntity Service
    /// </summary>
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TEntityService"/> class.
        /// </summary>
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(TEntity entity)
        {
            _repository.Add(entity);
        }

        /// <summary>
        /// Gets the specified id.
        /// </summary>
        /// <param name="i">The id.</param>
        /// <returns>
        /// Get by Id
        /// </returns>
        public TEntity Get(Expression<Func<TEntity, string>> queryExpression, string id)
        {
            return _repository.Get(queryExpression, id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// Get All
        /// </returns>
        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        public void Delete(IMongoQuery filterParam)
        {
            _repository.Delete(filterParam);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        /// <param name="entity">The entity.</param>
        public void Update(IMongoQuery filterParam, TEntity entity)
        {
            _repository.Update(filterParam, entity);
        }

        /// <summary>
        /// Filters the specified filter parameters.
        /// </summary>
        /// <param name="filterParams">The filter parameters.</param>
        public IQueryable<TEntity> Filter(Dictionary<string, string> filterParams)
        {
            return _repository.Filter(filterParams);
        }

        /// <summary>
        /// Filters the with query.
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        /// <returns></returns>
        public IQueryable<TEntity> FilterWithQuery(IMongoQuery filterParam)
        {
            return _repository.FilterWithQuery(filterParam);
        }
    }
}
