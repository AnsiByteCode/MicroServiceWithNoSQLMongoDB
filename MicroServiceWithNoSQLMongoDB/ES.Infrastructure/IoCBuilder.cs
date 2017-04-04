namespace ES.Infrastructure
{
    #region Using
    using Autofac;
    using Autofac.Integration.WebApi;
    using Core.Entities;
    using Core.Entities.ESEntities;
    using Core.Entities.Models;
    using ES.Infrastructure.Module;
    using ESSample.Common;
    using ESSample.Common.CartService;
    using ESSample.Common.CustomerService;
    using ESSample.Common.OrderService;
    using MassTransit;
    using System.Reflection;
    using System.Web.Http;
    #endregion

    /// <summary>
    /// IoC Builder
    /// </summary>
    public class IoCBuilder
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container { get; private set; }

        /// <summary>
        /// Initializes the web.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="configuration">The configuration.</param>
        public static void InitWeb(Assembly assembly, HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(assembly).InstancePerDependency();

            // Required for Web API! See http://stackoverflow.com/a/24141348/1062607
            builder.RegisterAssemblyTypes(assembly).PropertiesAutowired();

            // Module registration
            builder.RegisterModule<EventStoreModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<BusModule>();
            builder.RegisterModule<RepositoryModule>();

            
            builder = ConfigureInjections(builder);
            Container = builder.Build();
            var consumer = Container.Resolve<Core.Services.IService<Customer>>();
            // Start service bus
            var busControl = Container.Resolve<IBusControl>();
            busControl.Start();

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(Container);
            configuration.DependencyResolver = webApiResolver;
        }

        /// <summary>
        /// Configures the injections.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        private static ContainerBuilder ConfigureInjections(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork<Customer>>().AsSelf().WithParameter("helper", new ConnectionHelper(CustomerConfiguration.ConnectionString, CustomerConfiguration.DatabaseName, CustomerConfiguration.CustomerCollectionName));
            builder.RegisterType<Core.Repository.Repository<Customer>>().As<Core.Repository.IRepository<Customer>>();
            builder.RegisterType<Core.Services.Service<Customer>>().As<Core.Services.IService<Customer>>();

            builder.RegisterType<UnitOfWork<Product>>().AsSelf().WithParameter("helper", new ConnectionHelper(ProductConfiguration.ConnectionString, ProductConfiguration.DatabaseName, ProductConfiguration.ProductCollectionName));
            builder.RegisterType<Core.Repository.Repository<Product>>().As<Core.Repository.IRepository<Product>>();
            builder.RegisterType<Core.Services.Service<Product>>().As<Core.Services.IService<Product>>();

            builder.RegisterType<UnitOfWork<Cart>>().AsSelf().WithParameter("helper", new ConnectionHelper(CartConfiguration.ConnectionString, CartConfiguration.DatabaseName, CartConfiguration.CartCollectionName));
            builder.RegisterType<Core.Repository.Repository<Cart>>().As<Core.Repository.IRepository<Cart>>();
            builder.RegisterType<Core.Services.Service<Cart>>().As<Core.Services.IService<Cart>>();

            builder.RegisterType<UnitOfWork<Order>>().AsSelf().WithParameter("helper", new ConnectionHelper(OrderConfiguration.ConnectionString, OrderConfiguration.DatabaseName, OrderConfiguration.OrderCollectionName));
            builder.RegisterType<Core.Repository.Repository<Order>>().As<Core.Repository.IRepository<Order>>();
            builder.RegisterType<Core.Services.Service<Order>>().As<Core.Services.IService<Order>>();

            builder.RegisterType<UnitOfWork<SnapshotEntity>>().AsSelf().WithParameter("helper", new ConnectionHelper(EventStoreConfiguration.ConnectionString, EventStoreConfiguration.DatabaseName, EventStoreConfiguration.SnapShotCollectionName));
            builder.RegisterType<Core.Repository.Repository<SnapshotEntity>>().As<Core.Repository.IRepository<SnapshotEntity>>();
            builder.RegisterType<Core.Services.Service<SnapshotEntity>>().As<Core.Services.IService<SnapshotEntity>>();

            builder.RegisterType<UnitOfWork<Events>>().AsSelf().WithParameter("helper", new ConnectionHelper(EventStoreConfiguration.ConnectionString, EventStoreConfiguration.DatabaseName, EventStoreConfiguration.EventsCollectionName));
            builder.RegisterType<Core.Repository.Repository<Events>>().As<Core.Repository.IRepository<Events>>();
            builder.RegisterType<Core.Services.Service<Events>>().As<Core.Services.IService<Events>>();

            builder.RegisterType<UnitOfWork<EventStreams>>().AsSelf().WithParameter("helper", new ConnectionHelper(EventStoreConfiguration.ConnectionString, EventStoreConfiguration.DatabaseName, EventStoreConfiguration.EventStreamCollectionName));
            builder.RegisterType<Core.Repository.Repository<EventStreams>>().As<Core.Repository.IRepository<EventStreams>>();
            builder.RegisterType<Core.Services.Service<EventStreams>>().As<Core.Services.IService<EventStreams>>();
            return builder;
        }
    }
}
