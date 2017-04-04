namespace ES.ApplicationService
{
    #region Using
    using MassTransit;
    #endregion

    /// <summary>
    /// IRequest Client Creator
    /// </summary>
    public interface IRequestClientCreator
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns></returns>
        IRequestClient<TRequest, TResponse> Create<TRequest, TResponse>()
            where TRequest : class
            where TResponse : class;
    }
}
