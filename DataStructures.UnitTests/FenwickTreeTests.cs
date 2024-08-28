using DataStructures.DataStructures;

namespace DataStructures.UnitTests
{
    public class FenwickTreeTests
    {
        [Fact]
        public void Should_Update()
        {
            List<int> initialData = [ 1, 1, 1, 1, 1, 1 ];
            FenwickTree fenwickTree = new(initialData);

            fenwickTree.Update(6, 2);

            Assert.Equal(3, fenwickTree.Query(3)); // (1 + 1 + 1 + .. + .. + ..)
            Assert.Equal(4, fenwickTree.RangeQuery(2, 5)); // (.. + 1 + 1 + 1 + 1 + ..)
            Assert.Equal(8, fenwickTree.Query(6)); // (1 + 1 + 1 + 1 + 1 + 3)
        }
    }
}