using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Queridometro.Core.DomainObjects
{
    public abstract class Entity
    {
        [BsonIgnore]
        public Guid Id { get; set; }
    
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        private List<Event> _notifications;
        public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();
        public void AddEvent(Event @event)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(@event);
        }
        public void RemoveEvent(Event @event) 
        {
            _notifications?.Remove(@event);
        }
        public void ClearEvents()
        {
            _notifications.Clear();
        }
    }
}