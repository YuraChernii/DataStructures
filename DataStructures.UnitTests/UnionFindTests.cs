using DataStructures.DataStructures;

namespace DataStructures.UnitTests
{
    public class UnionFindTests
    {
        [Fact]
        public void Should_Union()
        {
            UnionFind uf = new(10);

            uf.Union(1, 2);
            uf.Union(3, 4);
            uf.Union(1, 4);
            uf.Union(5, 6);
            uf.Union(4, 5);

            Assert.True(uf.Connected(1, 2));
            Assert.True(uf.Connected(1, 6));
            Assert.False(uf.Connected(1, 7));
        }
    }
}