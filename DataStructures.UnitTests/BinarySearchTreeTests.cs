using DataStructures.DataStructures;

namespace DataStructures.UnitTests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void Should_Delete()
        {
            BinarySearchTree bst = new();

            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(70);
            bst.Insert(60);
            bst.Insert(80);
            bst.Insert(10);
            bst.Delete(60);
            bst.Delete(30);

            Assert.Collection(bst.InOrderTraversal(),
                value => Assert.Equal(10, value),
                value => Assert.Equal(20, value),
                value => Assert.Equal(40, value),
                value => Assert.Equal(50, value),
                value => Assert.Equal(70, value),
                value => Assert.Equal(80, value)
            );
            Assert.True(bst.Search(70));
            Assert.False(bst.Search(90));
        }
    }
}