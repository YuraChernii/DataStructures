using DataStructures.DataStructures;

namespace DataStructures.UnitTests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void Shoould_Enqueue()
        {
            PriorityQueue<string> pq = new();

            pq.Enqueue("10", 10);
            pq.Enqueue("3", 3);
            pq.Enqueue("4", 4);
            pq.Enqueue("1", 1);
            pq.Enqueue("2", 2);
            pq.Enqueue("4", 4);
            pq.Enqueue("-100", -100);

            Assert.Equal("-100", pq.Peek());
            Assert.Equal("-100", pq.Dequeue());
            Assert.Equal("1", pq.Dequeue());
            Assert.Equal("2", pq.Dequeue());
            Assert.Equal("3", pq.Dequeue());
            Assert.False(pq.IsEmpty());
        }
    }
}
