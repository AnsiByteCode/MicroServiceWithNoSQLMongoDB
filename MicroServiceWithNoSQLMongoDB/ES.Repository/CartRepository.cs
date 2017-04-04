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
    /// Cart Repository
    /// </summary>
    /// <seealso cref="ES.Contracts.ICartRepository" />
    public class CartRepository : ICartRepository
    {
        /// <summary>
        /// The _event store
        /// </summary>
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartRepository"/> class.
        /// </summary>
        /// <param name="eventStore">The event store.</param>
        public CartRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        /// <summary>
        /// Adds the specified Cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public void Add(Cart cart)
        {
            var streamName = StreamNameFor(cart.Id);
            _eventStore.CreateNewStream(streamName, cart.Changes);
        }

        /// <summary>
        /// Saves the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        public void Save(Cart cart)
        {
            var streamName = StreamNameFor(cart.Id);
            var expectedVersion = GetExpectedVersion(cart.InitialVersion);
            _eventStore.AppendEventsToStream(streamName, cart.Changes, expectedVersion);
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public Cart FindById(Guid cartId)
        {
            var fromEventNumber = 0;
            const int toEventNumber = int.MaxValue;

            var snapshot = _eventStore.GetLatestSnapshot<CartSnapshot>(StreamNameFor(cartId));
            if (snapshot != null)
            {
                fromEventNumber = snapshot.Version + 1; // load only events after snapshot
            }

            var domainEvents = _eventStore.GetStream(StreamNameFor(cartId), fromEventNumber, toEventNumber);

            Cart cart = null;

            cart = snapshot != null
                ? new Cart(snapshot)
                : new Cart();

            foreach (var @event in domainEvents.OrderBy(x => x.Version))
            {
                cart.Apply(@event);
            }

            return cart;
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
        /// <param name="cart">The cart.</param>
        public void SaveSnapshot(CartSnapshot snapshot, Cart cart)
        {
            var previousSnapshot = GetLatestSnapshot(cart.Id);
            if (previousSnapshot == null || previousSnapshot.Version < snapshot.Version)
            {
                _eventStore.AddSnapshot(StreamNameFor(cart.Id), snapshot);
            }
        }

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public CartSnapshot GetLatestSnapshot(Guid cartId)
        {
            return _eventStore.GetLatestSnapshot<CartSnapshot>(StreamNameFor(cartId));
        }

        /// <summary>
        /// Gets the history for cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<HistoryItem>> GetHistoryForCart(Guid cartId)
        {
            var history = await _eventStore.GetHistoryForAggregate(StreamNameFor(cartId), fromVersion: 0, toVersion: int.MaxValue);
            return history;
        }

        /// <summary>
        /// Streams the name for.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private string StreamNameFor(Guid id)
        {
            return $"{typeof(Cart).Name}@{id}";
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
