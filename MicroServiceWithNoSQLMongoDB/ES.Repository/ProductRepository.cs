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
    /// Product Repository
    /// </summary>
    /// <seealso cref="ES.Contracts.IProductRepository" />
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// The _event store
        /// </summary>
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="eventStore">The event store.</param>
        public ProductRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        /// <summary>
        /// Adds the specified Product.
        /// </summary>
        /// <param name="Product">The Product.</param>
        public void Add(Product Product)
        {
            var streamName = StreamNameFor(Product.Id);
            _eventStore.CreateNewStream(streamName, Product.Changes);
        }

        /// <summary>
        /// Saves the specified Product.
        /// </summary>
        /// <param name="Product">The Product.</param>
        public void Save(Product Product)
        {
            var streamName = StreamNameFor(Product.Id);
            var expectedVersion = GetExpectedVersion(Product.InitialVersion);
            _eventStore.AppendEventsToStream(streamName, Product.Changes, expectedVersion);
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="ProductId">The Product identifier.</param>
        /// <returns></returns>
        public Product FindById(Guid ProductId)
        {
            var fromEventNumber = 0;
            const int toEventNumber = int.MaxValue;

            var snapshot = _eventStore.GetLatestSnapshot<ProductSnapshot>(StreamNameFor(ProductId));
            if (snapshot != null)
            {
                fromEventNumber = snapshot.Version + 1; // load only events after snapshot
            }

            var domainEvents = _eventStore.GetStream(StreamNameFor(ProductId), fromEventNumber, toEventNumber);

            Product Product = null;

            Product = snapshot != null
                ? new Product(snapshot)
                : new Product();

            foreach (var @event in domainEvents.OrderBy(x => x.Version))
            {
                Product.Apply(@event);
            }

            return Product;
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
        /// <param name="Product">The Product.</param>
        public void SaveSnapshot(ProductSnapshot snapshot, Product Product)
        {
            var previousSnapshot = GetLatestSnapshot(Product.Id);
            if (previousSnapshot == null || previousSnapshot.Version < snapshot.Version)
            {
                _eventStore.AddSnapshot(StreamNameFor(Product.Id), snapshot);
            }
        }

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="ProductId">The Product identifier.</param>
        /// <returns></returns>
        public ProductSnapshot GetLatestSnapshot(Guid ProductId)
        {
            return _eventStore.GetLatestSnapshot<ProductSnapshot>(StreamNameFor(ProductId));
        }

        /// <summary>
        /// Gets the history for Product.
        /// </summary>
        /// <param name="ProductId">The Product identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<HistoryItem>> GetHistoryForProduct(Guid ProductId)
        {
            var history = await _eventStore.GetHistoryForAggregate(StreamNameFor(ProductId), fromVersion: 0, toVersion: int.MaxValue);
            return history;
        }

        /// <summary>
        /// Streams the name for.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private string StreamNameFor(Guid id)
        {
            return $"{typeof(Product).Name}@{id}";
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
