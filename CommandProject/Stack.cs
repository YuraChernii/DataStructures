

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandProject
{
    
    class Stack<T>
        where T: class
    {
        public string temp { get; set; } = "test";
        List<T> list = new List<T>();
        public void Push(T element)
        {
            list.Add(element);
        }

        public T Pop()
        {
            if (list.Count() == 0)
                throw new Exception("The stack is empty");

            var popElement = list.Last();
            list.Remove(list.Last());
            return popElement;
        }



        public void PushRange(IEnumerable<T> elements)
        {

            PushRange(elements, 0, elements.Count());
        }
        public void PushRange(IEnumerable<T> elements, int start, int length)
        {

            list.AddRange(elements);
        }
    }
}

