using System;
using System.Collections.Generic;
using System.Text;


namespace QueueAndHashTable
{
    class LinkedList<T>
        where T : struct
    {
        public Node<T> Kernel { get; set; }

        public LinkedList() { }
        public LinkedList(T data)
        {
            Kernel = new Node<T>();

            Kernel.Data = data;
            Kernel.Next = null;
            Kernel.Privious = null;
        }

        public void InsertLast(T data)
        {
            Node<T> tempKernel = Kernel;

            while (tempKernel.Next != null)
            {
                tempKernel = tempKernel.Next;
            }

            tempKernel.Next = new Node<T>(data);
            tempKernel.Next.Privious = tempKernel;
            tempKernel.Next.Next = null;

        }
        public void InsertFirst(T data)
        {
            Node<T> tempKernel = Kernel;

            while (tempKernel.Privious != null)
            {
                tempKernel = tempKernel.Privious;
            }

            tempKernel.Privious = new Node<T>(data);
            tempKernel.Privious.Next = tempKernel;
            tempKernel.Privious.Privious = null;
        }

    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Privious { get; set; }

        public Node()
        {

        }
        public Node(T _data)
        {
            Data = _data;
        }
    }

    public class StaticQueue<T>
    {
        public int rear; // Кінець черги. Додаються сюди
        public int front; // Початок черги. 
        private int count; 
        private Node<T> [] staticArray;

        public StaticQueue(int size)
        {
            staticArray = new Node<T>[size];
            front = size - 1;
            rear = size - 1;
            count = 0;
        }
        
        public void Enqueue(T data)
        {
            var newNode = new Node<T>(data);

            if (data == null)
            {
                throw new Exception("Data is null");
            }

            if(count == staticArray.Length)
            {
                throw new Exception("Queue overflow");
            }


            staticArray[rear--] = newNode;

            if(rear < 0)
            {
                rear = staticArray.Length - 1;
            }

            ++count;
        }

        public Node<T> Dequeue()
        {
            if(count == 0)
            {
                throw new Exception("Queue is empty");
            }

            Node<T> result = staticArray[front];
            
            staticArray[front--] = null;

            if (front < 0)
            {
                front = staticArray.Length - 1;
            }

            --count;

            return result;
        }

        public void printAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node<T> el in staticArray ){

                if(el == null)
                {
                    continue;
                }

                sb.Append(el.Data);
                sb.Append(" ");
            }

            Console.WriteLine(sb);
        }
    }
    

    class DynamicQueue<T>
    {
        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }

        public DynamicQueue()
        {

        }

       /* public InQue(T inputValue)
        {
            if (Last == null)
            {
                First = new Node<T>(inputValue);
                First.Privious = null;

                Last = new Node<T>(inputValue);
                Last.Privious = null;
            }
            else
            {
                Last.Privious = new Node<T>(inputValue);
                Last.Privious.Privious = null;
            }
        }

        public DeQue(T outputValue)
        {

            var firstEl = First.Previous;
            var returnValue = First;
            First = firstEl;
            return returnValue;
        }*/
    }
}
