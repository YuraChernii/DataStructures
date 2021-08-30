using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommandProject
{
    class Node<T>
    {

        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
        public Node() { }
        public Node(T data)
        {
            this.Data = data;
        }
    }

    class LinkedList<T>
        where T: struct
    {
        public Node<T> Kernel { get; set; }

        public LinkedList() {    }
        public LinkedList(T data)
        {
            Kernel = new Node<T>();

            Kernel.Data = data;
            Kernel.Next = null;
            Kernel.Previous = null;
        }

        public void InsertLast(T data)
        {
            Node<T> tempKernel = Kernel;

            while(tempKernel.Next != null)
            {
                tempKernel = tempKernel.Next;
            }

            tempKernel.Next = new Node<T>(data);
            tempKernel.Next.Previous = tempKernel;
            tempKernel.Next.Next = null;

        }
        public void InsertFirst(T data)
        {
            Node<T> tempKernel = Kernel;

            while (tempKernel.Previous != null)
            {
                tempKernel = tempKernel.Previous;
            }

            tempKernel.Previous = new Node<T>(data);
            tempKernel.Previous.Next = tempKernel;
            tempKernel.Previous.Previous = null;
        }

    }
}
