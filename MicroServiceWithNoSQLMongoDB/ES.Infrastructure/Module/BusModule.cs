namespace ES.Infrastructure.Module
{
    #region Using
    using Autofac;
    using Consumers;
    using ESSample.Common;
    using MassTransit;
    using System;
    using System.Configuration;
    #endregion

    /// <summary>
    /// Bus Module
    /// </summary>
    /// <seealso cref="ES.Infrastructure.Module" />
    public class BusModule : Module
    {
        /// <summary>
        /// Loads the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
           
            var useInMemoryBus = bool.Parse(BusConfiguration.UseInMemoryBus);

            if (useInMemoryBus)
            {
                builder.Register(ConfigureInMemoryBus)
                    .SingleInstance()
                    .As<IBusControl>()
                    .As<IBus>();
            }
            else
            {
                builder.Register(ConfigureRabbitMq)
                    .SingleInstance()
                    .As<IBusControl>()
                    .As<IBus>();
            }
            builder.RegisterConsumers(typeof(GetLoginDetailsConsumer).Assembly);

        }

        /// <summary>
        /// Configures the in memory bus.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IBusControl ConfigureInMemoryBus(IComponentContext context)
        {
            var busControl =
                Bus.Factory.CreateUsingInMemory(cfg => { cfg.ReceiveEndpoint(BusConfiguration.EndPoint, ep => ep.LoadFrom(context)); });
            return busControl;
        }

        /// <summary>
        /// Configures the rabbit mq.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private static IBusControl ConfigureRabbitMq(IComponentContext context)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(BusConfiguration.RabbitMqUri),
                    h =>
                    {
                        h.Username(BusConfiguration.RabbitMqUser);
                        h.Password(BusConfiguration.RabbitMqPassword);
                    });

                cfg.ReceiveEndpoint(host, BusConfiguration.EndPoint, e => { e.LoadFrom(context); });
            });
            return busControl;
        }
    }
}
