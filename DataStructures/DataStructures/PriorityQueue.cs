using System.Collections.Generic;
using System;

namespace DataStructures.DataStructures
{
    public class PriorityQueue<T>
    {
        private readonly List<(T item, int priority)> heap = [];

        public PriorityQueue()
        {
        }

        public void Enqueue(T item, int priority)
        {
            heap.Add((item, priority));
            HeapifyUp(heap.Count - 1);
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T rootItem = heap[0].item;
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            HeapifyDown(0);

            return rootItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return heap[0].item;
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index].priority >= heap[parentIndex].priority)
                {
                    break;
                }

                Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;
            while (index < lastIndex)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int smallestIndex = index;

                if (leftChildIndex <= lastIndex && heap[leftChildIndex].priority < heap[smallestIndex].priority)
                {
                    smallestIndex = leftChildIndex;
                }

                if (rightChildIndex <= lastIndex && heap[rightChildIndex].priority < heap[smallestIndex].priority)
                {
                    smallestIndex = rightChildIndex;
                }

                if (smallestIndex == index)
                {
                    break;
                }

                Swap(index, smallestIndex);
                index = smallestIndex;
            }
        }

        private void Swap(int index1, int index2) =>
            (heap[index2], heap[index1]) = (heap[index1], heap[index2]);
    }
}
