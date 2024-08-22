using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.DataStructures
{
    public class Stack<T>
    {
        private readonly List<T> _list = [];

        public void Push(T element)
        {
            _list.Add(element);
        }

        public void Push(IEnumerable<T> elements)
        {
            _list.AddRange(elements);
        }

        public T Pop()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            T popElement = _list.Last();
            _list.Remove(_list.Last());

            return popElement;
        }
    }
}