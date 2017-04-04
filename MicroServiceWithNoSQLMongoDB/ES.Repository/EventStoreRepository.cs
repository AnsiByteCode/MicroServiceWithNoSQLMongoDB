namespace ES.Repository
{
    using Common;
    #region Using
    using ES.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion

    public class EventStoreRepository<TEntity,TSnapshot> : IEventStoreRepository<TEntity, TSnapshot> where TEntity : EventSourcedAggregate where TSnapshot : Snapshot
    {
        /// <summary>
        /// The _event store
        /// </summary>
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreRepository{TEntity, TSnapshot}"/> class.
        /// </summary>
        /// <param name="eventStore">The event store.</param>
        public EventStoreRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        
        public void Add(TEntity entity)
        {
            var streamName = StreamNameFor(entity.Id);
            _eventStore.CreateNewStream(streamName, entity.Changes);
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(TEntity entity)
        {
            var streamName = StreamNameFor(entity.Id);
            var expectedVersion = GetExpectedVersion(Convert.ToInt32(entity.GetType().GetProperty("InitialVersion")));
            _eventStore.AppendEventsToStream(streamName, entity.Changes, expectedVersion);
        }


        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TEntity FindById(Guid id)
        {
            var fromEventNumber = 0;
            const int toEventNumber = int.MaxValue;

            var snapshot = _eventStore.GetLatestSnapshot<TSnapshot>(StreamNameFor(id));
            if (snapshot != null)
            {
                fromEventNumber = snapshot.Version + 1; // load only events after snapshot
            }

            var domainEvents = _eventStore.GetStream(StreamNameFor(id), fromEventNumber, toEventNumber);

            TEntity entity = null;

            //entity = snapshot != null
            //    ? new TEntity(snapshot)
            //    : new TEntity();

            //foreach (var @event in domainEvents.OrderBy(x => x.Version))
            //{
            //    entity.Apply(@event);
            //}

            return entity;
        }

        /// <summary>
        /// Gets all ids.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Guid> GetAllIds()
        {
            return _eventStore.GetAllStreamIds();
        }
        
        public void SaveSnapshot(TSnapshot snapshot, TEntity entity)
        {
            var previousSnapshot = GetLatestSnapshot(entity.Id);
            if (previousSnapshot == null || previousSnapshot.Version < snapshot.Version)
            {
                _eventStore.AddSnapshot(StreamNameFor(entity.Id), snapshot);
            }
        }

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TSnapshot GetLatestSnapshot(Guid id)
        {
            return _eventStore.GetLatestSnapshot<TSnapshot>(StreamNameFor(id));
        }

        /// <summary>
        /// Gets the history for customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<HistoryItem>> GetHistoryForTEntity(Guid id)
        {
            var history = await _eventStore.GetHistoryForAggregate(StreamNameFor(id), fromVersion: 0, toVersion: int.MaxValue);
            return history;
        }

        /// <summary>
        /// Streams the name for.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private string StreamNameFor(Guid id)
        {
            return $"{typeof(TEntity).Name}@{id}";
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
