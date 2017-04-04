
namespace ES.Domain
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Order Entity
    /// </summary>
    /// <seealso cref="ES.Common.EventSourcedAggregate" />
    public class Order : EventSourcedAggregate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        public Order(OrderSnapshot snapshot)
        {
            InitialVersion = snapshot.Version;
            Id = Id;
            Version = Version;
            CustomerId = CustomerId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        public Order(Guid orderId, Guid customerId)
        {
            Causes(new OrderCreated(orderId, customerId));
        }

        /// <summary>
        /// Gets the initial version.
        /// </summary>
        /// <value>
        /// The initial version.
        /// </value>
        public int InitialVersion { get; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets the order snap shot.
        /// </summary>
        /// <returns></returns>
        public OrderSnapshot GetOrderSnapShot()
        {
            return new OrderSnapshot
            {
                Id = Id,
                Version = Version
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
        /// Whens the specified order created.
        /// </summary>
        /// <param name="orderCreated">The order created.</param>
        private void When(OrderCreated orderCreated)
        {
            Id = orderCreated.AggregateId;
            CustomerId = orderCreated.CustomerId;
        }
    }

    /// <summary>
    /// Order Snapshot
    /// </summary>
    /// <seealso cref="ES.Common.OrderSnapshot" />
    public class OrderSnapshot : Snapshot
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }
    }

}
