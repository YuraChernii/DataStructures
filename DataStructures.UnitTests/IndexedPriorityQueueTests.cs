using DataStructures.DataStructures;

namespace DataStructures.UnitTests
{
    public class IndexedPriorityQueueTests
    {
        [Fact]
        public void Shoould_Decrease_Key()
        {
            IndexedPriorityQueue<int> ipq = new(10);

            ipq.Insert(0, 5);
            ipq.Insert(1, 3);
            ipq.Insert(2, 4);
            ipq.Insert(3, 1);
            ipq.DeleteMin();
            ipq.DecreaseKey(0, 2);

            Assert.Equal(0, ipq.MinIndex());
        }
    }
}