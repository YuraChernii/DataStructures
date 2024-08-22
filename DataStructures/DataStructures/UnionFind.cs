namespace DataStructures.DataStructures
{
    public class UnionFind
    {
        private readonly int[] parent;
        private readonly int[] rank;

        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];

            for (int i = 0; i < size; i++)
            {
                parent[i] = i; // Each element is its own parent (self-loop)
                rank[i] = 1;   // Initialize rank to 1
            }
        }

        // Find the root of the element (with path compression)
        public int Find(int p)
        {
            if (parent[p] != p)
            {
                parent[p] = Find(parent[p]); // Path compression
            }
            return parent[p];
        }

        // Union of two sets (by rank)
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);

            if (rootP != rootQ)
            {
                if (rank[rootP] > rank[rootQ])
                {
                    parent[rootQ] = rootP;
                }
                else if (rank[rootP] < rank[rootQ])
                {
                    parent[rootP] = rootQ;
                }
                else
                {
                    parent[rootQ] = rootP;
                    rank[rootP] += 1;
                }
            }
        }

        // Check if two elements are in the same set
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }
    }
}