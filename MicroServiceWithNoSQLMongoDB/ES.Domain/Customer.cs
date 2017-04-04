namespace ES.Domain
{
    #region using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Customer Entity
    /// </summary>
    /// <seealso cref="ES.Common.EventSourcedAggregate" />
    public class Customer : EventSourcedAggregate
    {
        public Customer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        public Customer(CustomerSnapshot snapshot)
        {
            InitialVersion = snapshot.Version;
            Version = snapshot.Version;
            Email = snapshot.Email;
            Id = snapshot.Id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        public Customer(string email, string password)
        {
            Causes(new LoginRequested(Guid.NewGuid(), email, password));
        }

        /// <summary>
        /// Gets the initial version.
        /// </summary>
        /// <value>
        /// The initial version.
        /// </value>
        public int InitialVersion { get; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets the customer snapshot.
        /// </summary>
        /// <returns></returns>
        public CustomerSnapshot GetCustomerSnapshot()
        {
            return new CustomerSnapshot
            {
                Id = Id,
                Version = Version,
                Email = Email
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
        /// <param name="loginRequested">The login requested.</param>
        private void When(LoginRequested loginRequested)
        {
            Id = loginRequested.AggregateId;
            Email = loginRequested.Email;
        }
    }

    /// <summary>
    /// Customer Snapshot
    /// </summary>
    /// <seealso cref="ES.Common.Snapshot" />
    public class CustomerSnapshot : Snapshot
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
    }
}
