namespace ES.Infrastructure.Module
{
    #region Using
    using Autofac;
    using Repository;
    #endregion

    /// <summary>
    /// Repository Module
    /// </summary>
    /// <seealso cref="ES.Infrastructure.Module" />
    public class RepositoryModule : Module
    {
        /// <summary>
        /// Loads the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly).AsImplementedInterfaces();
        }
    }
}
