using System;

namespace ComfortWPF.Services
{
    public interface IMessageChannel
    {
        /// <summary>
        /// put value into channel with key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Put(string key, object value);
        /// <summary>
        /// get value from channel by key, and keep value in channel
        /// </summary>
        /// <param name="key"></param>
        object Peek(string key);
        /// <summary>
        /// get value from channel by key, and remove value in channel
        /// </summary>
        /// <param name="key"></param>
        object Take(string key);
        /// <summary>
        /// publish a value to a topic
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="value"></param>
        void Publish(string topic, object value);
        /// <summary>
        /// subscribe a topic
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="onValueChanged"></param>
        void Subscribe(string topic, Action<object> onValueChanged);
        /// <summary>
        /// unsubscribe a topic
        /// </summary>
        /// <param name="topic"></param>
        void Unsubscribe(string topic);
    }
}
