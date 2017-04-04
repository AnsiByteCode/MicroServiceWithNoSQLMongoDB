namespace ES.Repository
{
    #region Using
    using ES.Common;
    using ES.Domain;
    using ES.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Order Repository
    /// </summary>
    /// <seealso cref="ES.Contracts.IOrderRepository" />
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// The _event store
        /// </summary>
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="eventStore">The event store.</param>
        public OrderRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        /// <summary>
        /// Adds the specified Order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void Add(Order order)
        {
            var streamName = StreamNameFor(order.Id);
            _eventStore.CreateNewStream(streamName, order.Changes);
        }

        /// <summary>
        /// Saves the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void Save(Order order)
        {
            var streamName = StreamNameFor(order.Id);
            var expectedVersion = GetExpectedVersion(order.InitialVersion);
            _eventStore.AppendEventsToStream(streamName, order.Changes, expectedVersion);
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public Order FindById(Guid orderId)
        {
            var fromEventNumber = 0;
            const int toEventNumber = int.MaxValue;

            var snapshot = _eventStore.GetLatestSnapshot<OrderSnapshot>(StreamNameFor(orderId));
            if (snapshot != null)
            {
                fromEventNumber = snapshot.Version + 1; // load only events after snapshot
            }

            var domainEvents = _eventStore.GetStream(StreamNameFor(orderId), fromEventNumber, toEventNumber);

            Order order = null;

            order = snapshot != null
                ? new Order(snapshot)
                : new Order();

            foreach (var @event in domainEvents.OrderBy(x => x.Version))
            {
                order.Apply(@event);
            }

            return order;
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
        /// <param name="order">The order.</param>
        public void SaveSnapshot(OrderSnapshot snapshot, Order order)
        {
            var previousSnapshot = GetLatestSnapshot(order.Id);
            if (previousSnapshot == null || previousSnapshot.Version < snapshot.Version)
            {
                _eventStore.AddSnapshot(StreamNameFor(order.Id), snapshot);
            }
        }

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public OrderSnapshot GetLatestSnapshot(Guid orderId)
        {
            return _eventStore.GetLatestSnapshot<OrderSnapshot>(StreamNameFor(orderId));
        }

        /// <summary>
        /// Gets the history for order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<HistoryItem>> GetHistoryForOrder(Guid orderId)
        {
            var history = await _eventStore.GetHistoryForAggregate(StreamNameFor(orderId), fromVersion: 0, toVersion: int.MaxValue);
            return history;
        }

        /// <summary>
        /// Streams the name for.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private string StreamNameFor(Guid id)
        {
            return $"{typeof(Order).Name}@{id}";
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
