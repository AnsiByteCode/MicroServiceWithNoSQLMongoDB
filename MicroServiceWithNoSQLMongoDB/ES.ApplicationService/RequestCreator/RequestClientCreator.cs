namespace ES.ApplicationService
{
    using ESSample.Common;
    #region Using
    using MassTransit;
    using System;
    using System.Configuration;
    #endregion

    /// <summary>
    /// Request Client Creator
    /// </summary>
    /// <seealso cref="ES.ApplicationService.IRequestClientCreator" />
    public class RequestClientCreator : IRequestClientCreator
    {
        private readonly IBusControl _bus;
        private readonly Uri _serviceAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestClientCreator"/> class.
        /// </summary>
        /// <param name="bus">The bus.</param>
        public RequestClientCreator(IBusControl bus)
        {
            _bus = bus;
            var useInMemoryBus = bool.Parse(BusConfiguration.UseInMemoryBus);
            _serviceAddress = useInMemoryBus 
                ? new Uri(BusConfiguration.ServiceAddressInMemory)
                : new Uri(BusConfiguration.ServiceAddress);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <returns></returns>
        public IRequestClient<TRequest, TResponse> Create<TRequest, TResponse>()
            where TRequest : class
            where TResponse : class
        {
            return _bus.CreateRequestClient<TRequest, TResponse>(_serviceAddress, TimeSpan.FromSeconds(30));
        }
    }
}
