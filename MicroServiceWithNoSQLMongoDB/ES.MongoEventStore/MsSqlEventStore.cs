namespace ES.MongoEventStore
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Newtonsoft.Json;
    using Common.Exceptions;
    using Common;
    using MongoEventStore;
    using Core.Services;
    using Core.Entities.Models;
    using Core.Entities.ESEntities;
    using System.Collections;
    using MongoDB.Driver.Builders;
    using MongoDB.Bson;
    #endregion

    /// <summary>
    /// Ms Sql Event Store
    /// </summary>
    /// <seealso cref="ES.Common.IEventStore" />
    public class MsSqlEventStore : IEventStore
    {
        /// <summary>
        /// The event stream service
        /// </summary>
        public IService<EventStreams> eventStreamService;

        /// <summary>
        /// The events service
        /// </summary>
        public IService<Events> eventsService;

        /// <summary>
        /// The snap shot service
        /// </summary>
        public IService<SnapshotEntity> snapShotService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlEventStore" /> class.
        /// </summary>
        /// <param name="eventStreamService">The event stream service.</param>
        /// <param name="eventsService">The events service.</param>
        public MsSqlEventStore(IService<EventStreams> eventStreamService, IService<Events> eventsService, IService<SnapshotEntity> snapShotService)
        {
            this.eventStreamService = eventStreamService;
            this.eventsService = eventsService;
            this.snapShotService = snapShotService;
        }

        /// <summary>
        /// Creates the new stream.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="domainEvents">The domain events.</param>
        public void CreateNewStream(string streamName, IEnumerable<DomainEvent> domainEvents)
        {
            var eventStream = new EventStream(streamName.Id(), streamName.Type());
            AddEventStream(eventStream);
            var minVersion = 0;
            AppendEventsToStream(streamName, domainEvents, minVersion);
        }

        /// <summary>
        /// Appends the events to stream.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="domainEvents">The domain events.</param>
        /// <param name="expectedVersion">The expected version.</param>
        public void AppendEventsToStream(string streamName, IEnumerable<DomainEvent> domainEvents, int? expectedVersion)
        {
            var eventStream = GetEventStreamMeta(streamName.Id());

            if (expectedVersion != null)
            {
                CheckForConcurrencyError(expectedVersion, eventStream);
            }

            try
            {
                AddEvents(domainEvents.Select(@event => eventStream.RegisterEvent(@event)).ToList());
                UpdateStream(eventStream);
            }
            catch (Exception exc)
            {
                throw;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Gets the stream.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="fromVersion">From version.</param>
        /// <param name="toVersion">To version.</param>
        /// <returns></returns>
        public IEnumerable<DomainEvent> GetStream(string streamName, int fromVersion, int toVersion)
        {
            var domainEvents = new List<DomainEvent>();
            var query = Query.And(Query.Matches("Id", new BsonRegularExpression("/^" + streamName.Id().ToString() + "$/i")), Query.GTE("Version", fromVersion), Query.LTE("Version", toVersion));
            var eventStreams = eventsService.FilterWithQuery(query).ToList();
            foreach (var item in eventStreams)
            {
                var dbType = item.EventType;
                var dbVersion = item.Version;
                var dbPayload = item.Payload;
                var payload = JsonConvert.DeserializeObject(dbPayload, Type.GetType(dbType));
                var domainEvent = payload as DomainEvent;
                if (domainEvent != null)
                {
                    domainEvent.Version = dbVersion;
                    domainEvents.Add(domainEvent);
                }
            }
            return domainEvents;
        }

        /// <summary>
        /// Gets the history for aggregate.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="fromVersion">From version.</param>
        /// <param name="toVersion">To version.</param>
        /// <returns></returns>
        public async Task<IEnumerable<HistoryItem>> GetHistoryForAggregate(string streamName, int fromVersion, int toVersion)
        {
            return await Task.Run(() =>
            {
                var historyItems = new List<HistoryItem>();
                var query = Query.And(Query.Matches("EventStreamId", new BsonRegularExpression("/^" + streamName.Id().ToString() + "$/i")), Query.GTE("Version", fromVersion), Query.LTE("Version", toVersion));
                var eventStreams = eventsService.FilterWithQuery(query).ToList();
                foreach (var item in eventStreams)
                {
                    var dbType = item.EventType;
                    var dbVersion = item.Version;
                    var dbPayload = item.Payload;
                    var timeStampUtc = item.TimeStampUtc;
                    historyItems.Add(new HistoryItem
                    {
                        DomainEvent = dbPayload,
                        TimestampUtc = timeStampUtc,
                        Version = dbVersion,
                        Type = dbType
                    });
                }
                return historyItems;
            });
        }

        /// <summary>
        /// Adds the snapshot.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="snapshot">The snapshot.</param>
        public void AddSnapshot<T>(string streamName, T snapshot)
        {
            var wrapper = new SnapshotWrapper
            {
                StreamName = streamName.Id().ToString(),
                Snapshot = snapshot,
                Created = DateTime.UtcNow
            };

            var eventStreamGuid = new Guid(wrapper.StreamName);
            SnapshotEntity newSnapshot = new SnapshotEntity();
            newSnapshot.Id = wrapper.Id;
            newSnapshot.Payload = JsonConvert.SerializeObject(wrapper.Snapshot);
            newSnapshot.EventStreamId = eventStreamGuid;
            newSnapshot.CreatedUtc = wrapper.Created;

            snapShotService.Insert(newSnapshot);
        }

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <typeparam name="TSnapshot">The type of the snapshot.</typeparam>
        /// <param name="streamName">Name of the stream.</param>
        /// <returns></returns>
        public TSnapshot GetLatestSnapshot<TSnapshot>(string streamName) where TSnapshot : class
        {
            TSnapshot result = null;
            var snapshot = snapShotService.FilterWithQuery(Query.Matches("EventStreamId", new BsonRegularExpression("/^" + streamName.Id().ToString() + "$/i"))).OrderByDescending(x => x.CreatedUtc).FirstOrDefault();
            if (snapshot != null)
            {
                result = (TSnapshot)JsonConvert.DeserializeObject(snapshot.Payload, typeof(TSnapshot));
            }
            return result;
        }

        /// <summary>
        /// Gets all stream ids.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Guid> GetAllStreamIds()
        {
            return eventStreamService.GetAll().Select(x => x.Id).ToList();
        }

        /// <summary>
        /// Checks for concurrency error.
        /// </summary>
        /// <param name="expectedVersion">The expected version.</param>
        /// <param name="stream">The stream.</param>
        /// <exception cref="OptimsticConcurrencyException"></exception>
        private static void CheckForConcurrencyError(int? expectedVersion, EventStream stream)
        {
            var lastUpdatedVersion = stream.Version;
            if (lastUpdatedVersion != expectedVersion)
            {
                var error = $"Expected: {expectedVersion}. Found: {lastUpdatedVersion}";
                throw new OptimsticConcurrencyException(error);
            }
        }

        /// <summary>
        /// Updates the stream.
        /// </summary>
        /// <param name="eventStream">The event stream.</param>
        /// <param name="transaction">The transaction.</param>
        private void UpdateStream(EventStream eventStream)
        {
            var streamData = eventStreamService.FilterWithQuery(Query.Matches("Id", new BsonRegularExpression("/^" + eventStream.Id.ToString() + "$/i"))).FirstOrDefault();
            if (streamData != null)
            {
                streamData.Version = eventStream.Version;
                eventStreamService.Update(Query.Matches("Id", new BsonRegularExpression("/^" + eventStream.Id.ToString() + "$/i")), streamData);
            }
        }


        /// <summary>
        /// Adds the event stream.
        /// </summary>
        /// <param name="eventStream">The event stream.</param>
        /// <param name="transaction">The transaction.</param>
        private void AddEventStream(EventStream eventStream)
        {
            eventStreamService.Insert(new EventStreams() { Id = eventStream.Id, Type = eventStream.Type, Version = eventStream.Version });
        }

        /// <summary>
        /// Adds the events.
        /// </summary>
        /// <param name="events">The events.</param>
        /// <param name="transaction">The transaction.</param>
        private void AddEvents(List<EventWrapper> events)
        {
            foreach (var @event in events)
            {
                eventsService.Insert(new Events() { EventStreamId = @event.EventStreamId, EventType = @event.Type, Id = @event.Id, Payload = JsonConvert.SerializeObject(@event.Event), TimeStampUtc = @event.TimeStampUtc, Version = @event.EventNumber });
            }
        }

        /// <summary>
        /// Gets the event stream meta.
        /// </summary>
        /// <param name="eventStreamId">The event stream identifier.</param>
        /// <returns></returns>
        private EventStream GetEventStreamMeta(Guid eventStreamId)
        {
            EventStream result = null;
            var eventStream = eventStreamService.FilterWithQuery(Query.Matches("Id", new BsonRegularExpression("/^" + eventStreamId.ToString() + "$/i"))).FirstOrDefault();
            if (eventStream != null)
            {
                result = new EventStream(eventStream.Id, eventStream.Type, eventStream.Version);
            }
            return result;
        }
    }

}
