namespace ES.Infrastructure.Module
{
    #region Using
    using Autofac;
    using ES.MongoEventStore;
    #endregion

    /// <summary>
    /// Event Store Module
    /// </summary>
    /// <seealso cref="ES.Infrastructure.Module" />
    public class EventStoreModule : Autofac.Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(MsSqlEventStore).Assembly).AsImplementedInterfaces();
        }
    }
}
