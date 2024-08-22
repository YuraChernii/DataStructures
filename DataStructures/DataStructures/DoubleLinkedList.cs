namespace DataStructures.DataStructures
{
    public class DoubleLinkedList<T>
    {
        public DoubleLinkedList() { }
        public DoubleLinkedList(T data)
        {
            FirstNode = new(data);
        }

        public Node<T> FirstNode { get; private set; }

        public void InsertLast(T data)
        {
            Node<T> newNode = new(data);

            if (FirstNode == null)
            {
                FirstNode = newNode;
                return;
            }

            Node<T> currentNode = FirstNode;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            newNode.Previous = currentNode;
        }

        public void InsertFirst(T data)
        {
            Node<T> firstNode = FirstNode;
            Node<T> insertNode = new(data);
            FirstNode = insertNode;

            if (firstNode == null)
            {
                return;
            }

            insertNode.Next = firstNode;
            insertNode.Previous = firstNode.Previous;
            firstNode.Previous = insertNode;
        }
    }

    public class Node<T>
    {
        private Node() { }
        internal Node(T data)
        {
            Data = data;
        }

        internal T Data { get; set; }
        internal Node<T> Next { get; set; }
        internal Node<T> Previous { get; set; }
    }
}