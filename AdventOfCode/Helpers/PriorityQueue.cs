using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Helpers
{
    public class PriorityQueue<TElement>
    {
        private readonly ConcurrentDictionary<int, Queue<TElement>> _priorityQueue;
        private int _lowestPrio;

        public PriorityQueue()
        {
            _priorityQueue = new ConcurrentDictionary<int, Queue<TElement>>();
            _lowestPrio = int.MaxValue;
        }

        public void Enqueue(TElement element, int priority)
        {
            _priorityQueue.GetOrAdd(priority, (e) => new Queue<TElement>()).Enqueue(element);
            _lowestPrio = (priority < _lowestPrio) ? priority : _lowestPrio;
        }

        public TElement Dequeue()
        {
            if (_priorityQueue.TryGetValue(_lowestPrio, out var queue))
            {
                var element =  queue.Dequeue();
                if (queue.Count == 0)
                {
                    _priorityQueue.Remove(_lowestPrio, out _);
                    _lowestPrio = _priorityQueue.IsEmpty ? int.MaxValue : _priorityQueue.Keys.Min();
                }

                return element;
            }

            throw new ArgumentException($"Queue is empty");
        }

        public int Count()
        {
            return _priorityQueue.Sum(p => p.Value.Count);
        }

        public bool Any()
        {
            return !_priorityQueue.IsEmpty;
        }
    }
}
