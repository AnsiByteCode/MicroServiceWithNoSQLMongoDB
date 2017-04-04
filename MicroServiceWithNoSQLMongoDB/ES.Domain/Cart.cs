using ES.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    /// <summary>
    /// Cart Entity
    /// </summary>
    /// <seealso cref="ES.Common.EventSourcedAggregate" />
    public class Cart : EventSourcedAggregate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        public Cart() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        public Cart(CartSnapshot snapshot)
        {
            InitialVersion = snapshot.Version;
            Id = Id;
            Version = Version;
            Category = Category;
            CustomerId = CustomerId;
            Description = Description;
            Name = Name;
            Price = Price;
            ProductId = ProductId;
            Qty = Qty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="mode">The mode.</param>
        public Cart(Guid Id, string name, string category, string description, decimal price, int qty, Guid productId, Guid customerId, string mode)
        {
            Causes(new CartUpdated(Id, name, category, description, price, qty, productId, customerId, mode));
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
        /// Gets or sets the Category.
        /// </summary>
        /// <value>
        /// The Category.
        /// </value>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the Qty
        /// </summary>
        /// <value>
        /// The Qty
        /// </value>
        public int? Qty { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets the customer snapshot.
        /// </summary>
        /// <returns></returns>
        public CartSnapshot GetCartSnapShot()
        {
            return new CartSnapshot
            {
                Id = Id,
                Version = Version,
                Category = Category,
                CustomerId = CustomerId,
                Description = Description,
                Name = Name,
                Price = Price,
                ProductId = ProductId,
                Qty = Qty
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
        /// Whens the specified login requested.
        /// </summary>
        /// <param name="cartUpdated">The cart updated.</param>
        private void When(CartUpdated cartUpdated)
        {
            Id = cartUpdated.AggregateId;
            CustomerId = cartUpdated.CustomerId;
            Name = cartUpdated.Name;
            Category = cartUpdated.Category;
            Description = cartUpdated.Description;
            Price = cartUpdated.Price;
            Qty = cartUpdated.Qty;
            ProductId = cartUpdated.ProductId;
        }
    }

    /// <summary>
    /// Cart Snapshot
    /// </summary>
    /// <seealso cref="ES.Common.Snapshot" />
    public class CartSnapshot : Snapshot
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        /// <value>
        /// The Category.
        /// </value>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the Qty
        /// </summary>
        /// <value>
        /// The Qty
        /// </value>
        public int? Qty { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }
    }

}
