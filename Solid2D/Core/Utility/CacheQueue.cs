using System.Collections.Generic;

namespace Core.Utility
{
    /// <summary>
    /// Quaue used for cache
    /// </summary>
    /// <typeparam name="T">Type of items</typeparam>
    public class CacheQueue<T> where T : new ()
    {
        protected Queue<T> _queue;

        public CacheQueue()
        {
            _queue = new Queue<T>();
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
            {
                return new T();
            }
            return _queue.Dequeue();
        }

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }
    }
}
