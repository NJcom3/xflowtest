using System;
using System.Collections.Generic;

namespace Core.Events
{
    public class EventBus
    {
        private readonly Dictionary<Type, Delegate> _eventDictionary = new();

        public void Subscribe<T>(Action<bool> eventHandler) where T : class
        {
            if (!_eventDictionary.ContainsKey(typeof(T)))
            {
                _eventDictionary[typeof(T)] = null;
            }

            _eventDictionary[typeof(T)] = (Action<bool>)_eventDictionary[typeof(T)] + eventHandler;
        }

        public void Unsubscribe<T>(Action<bool> eventHandler) where T : class
        {
            if (_eventDictionary.ContainsKey(typeof(T)))
            {
                _eventDictionary[typeof(T)] = (Action<bool>)_eventDictionary[typeof(T)] - eventHandler;
            }
        }

        public void Publish<T>() where T : class
        {
            if (_eventDictionary.ContainsKey(typeof(T)))
            {
                _eventDictionary[typeof(T)]?.DynamicInvoke(false);
            }
        }

        public void Publish<T>(bool value) where T : class
        {
            if (_eventDictionary.ContainsKey(typeof(T)))
            {
                _eventDictionary[typeof(T)]?.DynamicInvoke(value);
            }
        }
    }
}