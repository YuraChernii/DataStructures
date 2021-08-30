using System;

namespace QueueAndHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueAndHashTable.StaticQueue<int> staticQueue = new QueueAndHashTable.StaticQueue<int>(10);

            for(int i =0; i < 5; ++i)
            {
                staticQueue.Enqueue(i);
            }

            staticQueue.printAll();

            for (int i = 0; i < 3; ++i)
            {
                staticQueue.Dequeue();
            }

            staticQueue.printAll();

            for (int i = 10; i < 17; ++i)
            {
                staticQueue.Enqueue(i);
            }

            staticQueue.printAll();

            for (int i = 0; i < 8; ++i)
            {
                staticQueue.Dequeue();
            }

            staticQueue.printAll();

        }
    }
}
