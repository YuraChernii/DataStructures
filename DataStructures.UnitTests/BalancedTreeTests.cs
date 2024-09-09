using DataStructures.DataStructures;

namespace DataStructures.UnitTests
{
    public class BalancedTreeTests
    {
        [Fact]
        public void Should_Insert()
        {
            BalancedTree t = new(3);

            t.Insert(10);
            t.Insert(20);
            t.Insert(5);
            t.Insert(6);
            t.Insert(12);
            t.Insert(30);
            t.Insert(7);
            t.Insert(17);

            Assert.NotNull(t.Search(6));
            Assert.Null(t.Search(15));
        }
    }
}