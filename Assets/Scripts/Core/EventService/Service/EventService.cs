using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.EventService.Interface;

namespace Core.EventService.Service
{
    public sealed class Event<T>
    {        
        public event Action<T> EventName;
        public void OnEventName(T obj)
        {
            EventName?.Invoke(obj);
        }
    }
    public static class Events<T>
    {
        public static readonly Dictionary<byte, Event<T>> AllEvents = new();
    }
    public class EventService : IEventService
    {
        
        public Task Inject()
        {
            return Task.CompletedTask;
        }
        
        public void Subscribe<T>(byte evtName, Action<T> listener) {
            if (Events<T>.AllEvents.TryGetValue(evtName, out var evt))
            {
                evt.EventName += listener;
            }
            else
            {
                evt = new Event<T>();
                evt.EventName += listener;
                Events<T>.AllEvents.Add(evtName, evt);
            }
        }
        
        public void UnSubscribe<T>(byte evtName, Action<T> listener) {
            if (Events<T>.AllEvents.TryGetValue(evtName, out var evt))
                evt.EventName -= listener;
        }
        
        public void Fire<T>(byte evtName,T data)
        {
            if (Events<T>.AllEvents.TryGetValue(evtName, out var evt))
                    evt.OnEventName(data);
        }

    }
}