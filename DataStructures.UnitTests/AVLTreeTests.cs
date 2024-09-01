using DataStructures.DataStructures;

namespace DataStructures.UnitTests
{
    public class AVLTreeTests
    {
        [Fact]
        public void Should_Insert()
        {
            AVLTree<int> avlTree = new();

            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(30);
            avlTree.Insert(40);
            avlTree.Insert(50);
            avlTree.Insert(25);

            Assert.Collection(avlTree.InOrderTraversal(),
                value => Assert.Equal(10, value),
                value => Assert.Equal(20, value),
                value => Assert.Equal(25, value),
                value => Assert.Equal(30, value),
                value => Assert.Equal(40, value),
                value => Assert.Equal(50, value)
            );
        }
    }
}