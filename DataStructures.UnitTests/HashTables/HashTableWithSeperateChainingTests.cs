using DataStructures.DataStructures.HashTables;

namespace DataStructures.UnitTests.HashTables
{
    public class HashTableWithSeperateChainingTests
    {
        [Fact]
        public void Should_Remove_KeyValue_From_HashTable()
        {
            HashTableWithSeperateChaining<string, int> hashTable = new();

            hashTable.Add("one", 1);
            hashTable.Add("two", 2);
            hashTable.Add("three", 3);
            hashTable.Remove("two");

            int two = hashTable.TryGetValue("two", out int value) ? value : 0;
            Assert.Equal(0, two);
            Assert.Throws<KeyNotFoundException>(() => hashTable["two"]);
            Assert.Equal(1, hashTable["one"]);
            Assert.Equal(3, hashTable["three"]);
        }
    }
}