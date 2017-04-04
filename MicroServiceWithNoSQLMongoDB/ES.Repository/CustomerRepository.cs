namespace ES.Repository
{
    #region Using
    using ES.Common;
    using ES.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Customer Repository
    /// </summary>
    /// <seealso cref="ES.Contracts.ICustomerRepository" />
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// The _event store
        /// </summary>
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="eventStore">The event store.</param>
        public CustomerRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        /// <summary>
        /// Adds the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void Add(Customer customer)
        {
            var streamName = StreamNameFor(customer.Id);
            _eventStore.CreateNewStream(streamName, customer.Changes);
        }

        /// <summary>
        /// Saves the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void Save(Customer customer)
        {
            var streamName = StreamNameFor(customer.Id);
            var expectedVersion = GetExpectedVersion(customer.InitialVersion);
            _eventStore.AppendEventsToStream(streamName, customer.Changes, expectedVersion);
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public Customer FindById(Guid customerId)
        {
            var fromEventNumber = 0;
            const int toEventNumber = int.MaxValue;

            var snapshot = _eventStore.GetLatestSnapshot<CustomerSnapshot>(StreamNameFor(customerId));
            if (snapshot != null)
            {
                fromEventNumber = snapshot.Version + 1; // load only events after snapshot
            }

            var domainEvents = _eventStore.GetStream(StreamNameFor(customerId), fromEventNumber, toEventNumber);

            Customer customer = null;

            customer = snapshot != null
                ? new Customer(snapshot)
                : new Customer();

            foreach (var @event in domainEvents.OrderBy(x => x.Version))
            {
                customer.Apply(@event);
            }

            return customer;
        }

        /// <summary>
        /// Gets all ids.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Guid> GetAllIds()
        {
            return _eventStore.GetAllStreamIds();
        }

        /// <summary>
        /// Saves the snapshot.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        /// <param name="customer">The customer.</param>
        public void SaveSnapshot(CustomerSnapshot snapshot, Customer customer)
        {
            var previousSnapshot = GetLatestSnapshot(customer.Id);
            if (previousSnapshot == null || previousSnapshot.Version < snapshot.Version)
            {
                _eventStore.AddSnapshot(StreamNameFor(customer.Id), snapshot);
            }
        }

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public CustomerSnapshot GetLatestSnapshot(Guid customerId)
        {
            return _eventStore.GetLatestSnapshot<CustomerSnapshot>(StreamNameFor(customerId));
        }

        /// <summary>
        /// Gets the history for customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<HistoryItem>> GetHistoryForCustomer(Guid customerId)
        {
            var history = await _eventStore.GetHistoryForAggregate(StreamNameFor(customerId), fromVersion: 0, toVersion: int.MaxValue);
            return history;
        }

        /// <summary>
        /// Streams the name for.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private string StreamNameFor(Guid id)
        {
            return $"{typeof(Customer).Name}@{id}";
        }

        /// <summary>
        /// Gets the expected version.
        /// </summary>
        /// <param name="expectedVersion">The expected version.</param>
        /// <returns></returns>
        private int? GetExpectedVersion(int expectedVersion)
        {
            if (expectedVersion == 0)
            {
                // first time the aggregate is stored, there is no expected version
                return null;
            }
            return expectedVersion;
        }
    }
}
