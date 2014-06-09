using System;

namespace AccountDataGenerator
{
    public class EventJson
    {
        public readonly Guid EventId;
        public readonly string EventType;
        public readonly object Data;

        public EventJson(Guid eventId, string eventType, object data)
        {
            EventId = eventId;
            EventType = eventType;
            Data = data;
        }
    }
}