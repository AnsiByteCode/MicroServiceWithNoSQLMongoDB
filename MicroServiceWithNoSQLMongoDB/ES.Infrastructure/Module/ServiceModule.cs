namespace ES.Infrastructure.Module
{
    #region Using
    using ES.ApplicationService;
    using Autofac;
    #endregion

    /// <summary>
    /// Service Module
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class ServiceModule : Module
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
            builder.RegisterAssemblyTypes(typeof(CustomerService).Assembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(ProductService).Assembly).AsImplementedInterfaces();
        }
    }
}
