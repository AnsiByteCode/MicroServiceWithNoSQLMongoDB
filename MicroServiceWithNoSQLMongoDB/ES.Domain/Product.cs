
namespace ES.Domain
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Product class
    /// </summary>
    /// <seealso cref="ES.Common.EventSourcedAggregate" />
    public class Product : EventSourcedAggregate
    {
        /// <summary>
        /// The inserted
        /// </summary>
        public static string Inserted = "Inserted";

        /// <summary>
        /// The updated
        /// </summary>
        public static string Updated = "Updated";

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        public Product(ProductSnapshot snapshot)
        {
            InitialVersion = snapshot.Version;
            Version = snapshot.Version;
            Name = snapshot.Name;
            Id = snapshot.Id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="mode">The mode.</param>
        public Product(Guid id, string name, string category, string description, decimal price, int qty, string mode)
        {
            Causes(new ProductUpdated(id, name, category, description, price, qty, mode));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public Product(Guid Id)
        {
            Causes(new ProductDeleted(Id));
        }


        /// <summary>
        /// Gets the initial version.
        /// </summary>
        /// <value>
        /// The initial version.
        /// </value>
        public int InitialVersion { get; }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the customer snapshot.
        /// </summary>
        /// <returns></returns>
        public ProductSnapshot GetProductSnapshot()
        {
            return new ProductSnapshot
            {
                Id = Id,
                Version = Version,
                Name = Name
            };
        }


        /// <summary>
        /// Causeses the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        /// <summary>
        /// Applies the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        /// <summary>
        /// Whens the specified product Updated.
        /// </summary>
        /// <param name="productUpdated">The product Updated.</param>
        private void When(ProductUpdated productUpdated)
        {
            Id = productUpdated.AggregateId;
            Name = productUpdated.Name;
            Version = productUpdated.Version;
        }

        /// <summary>
        /// Whens the specified product deleted.
        /// </summary>
        /// <param name="productDeleted">The product deleted.</param>
        private void When(ProductDeleted productDeleted)
        {
            Id = productDeleted.AggregateId;
        }
    }

    /// <summary>
    /// Product Snapshot
    /// </summary>
    /// <seealso cref="ES.Common.Snapshot" />
    public class ProductSnapshot : Snapshot
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
