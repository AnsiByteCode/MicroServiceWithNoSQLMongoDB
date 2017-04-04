namespace Core.Services
{
    #region using
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// Ientity Service
    /// </summary>
    public interface IService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Gets the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>Get by Id</returns>
        TEntity Get(Expression<Func<TEntity, string>> queryExpression, string i);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Get All</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        void Delete(IMongoQuery filterParam);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        /// <param name="entity">The entity.</param>
        void Update(IMongoQuery filterParam, TEntity entity);

        /// <summary>
        /// Filters the specified filter parameters.
        /// </summary>
        /// <param name="filterParams">The filter parameters.</param>
        /// <returns></returns>
        IQueryable<TEntity> Filter(Dictionary<string, string> filterParams);

        /// <summary>
        /// Filters the with query.
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        /// <returns></returns>
        IQueryable<TEntity> FilterWithQuery(IMongoQuery filterParam);
    }
}
