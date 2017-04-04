namespace Core.Repository
{

    #region using 
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// Repository Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        ///<summary>  
        /// Generic Get method to get record on the basis of id  
        ///</summary>  
        ///<param name="i"></param>  
        ///<returns>Get by id</returns>  
        T Get(Expression<Func<T, string>> queryExpression, string id);

        ///<summary>  
        /// Get all records   
        ///</summary>  
        ///<returns>Get All</returns>  
        IQueryable<T> GetAll();

        ///<summary>  
        /// Generic add method to insert enities to collection   
        ///</summary>  
        ///<param name="entity"></param>  
        void Add(T entity);

        /// <summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        void Delete(IMongoQuery filterParam);

        /// <summary>
        /// Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="filterParam">The filter parameter.</param>
        /// <param name="entity">The entity.</param>
        void Update(IMongoQuery filterParam, T entity);

        /// <summary>
        /// Filters the specified query.
        /// </summary>
        /// <param name="filterParams">The filter parameters.</param>
        /// <returns></returns>
        IQueryable<T> Filter(Dictionary<string, string> filterParams);

        /// <summary>
        /// Filters the with query.
        /// </summary>
        /// <param name="filterParams">The filter parameters.</param>
        /// <returns></returns>
        IQueryable<T> FilterWithQuery(IMongoQuery filterParams); 
    }
}
