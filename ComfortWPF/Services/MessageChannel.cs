using System;
using System.Collections.Concurrent;
using System.ComponentModel.Composition;

namespace ComfortWPF.Services
{
    [Export(typeof(IMessageChannel))]
    public class MessageChannel : IMessageChannel
    {
        private static ConcurrentDictionary<string, object> cache = new ConcurrentDictionary<string, object>();

        public object Peek(string key)
        {
            object obj;
            cache.TryGetValue(key, out obj);
            return obj;
        }

        public void Publish(string topic, object value)
        {
            throw new NotImplementedException();
        }

        public void Put(string key, object value)
        {
            cache.AddOrUpdate(key, value, (k, v1) => v1);
        }

        public void Subscribe(string topic, Action<object> onValueChanged)
        {
            throw new NotImplementedException();
        }

        public object Take(string key)
        {
            object obj;
            cache.TryRemove(key, out obj);
            return obj;
        }

        public void Unsubscribe(string topic)
        {
            throw new NotImplementedException();
        }
    }
}
