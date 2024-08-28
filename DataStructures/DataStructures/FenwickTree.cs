using System.Collections.Generic;

namespace DataStructures.DataStructures
{
    public class FenwickTree
    {
        private readonly int[] tree;

        public FenwickTree(IList<int> initialData)
        {
            tree = new int[initialData.Count + 1];

            for (int i = 0; i < initialData.Count; i++)
            {
                Update(i + 1, initialData[i]);
            }
        }

        public void Update(int index, int value)
        {
            while (index < tree.Length)
            {
                tree[index] += value;
                index += index & -index;
            }
        }

        public int Query(int index)
        {
            int sum = 0;

            while (index > 0)
            {
                sum += tree[index];
                index -= index & -index;
            }

            return sum;
        }

        public int RangeQuery(int left, int right) =>
            Query(right) - Query(left - 1);
    }
}