namespace ES.Infrastructure.Module
{
    #region Using
    using Autofac;
    using ES.Infrastructure.Consumers;
    #endregion

    /// <summary>
    /// Consumer Module
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ConsumerModule : Autofac.Module
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
            builder.RegisterAssemblyTypes(typeof(GetLoginDetailsConsumer).Assembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(GetProductsConsumer).Assembly).AsImplementedInterfaces();
        }
    }
}
