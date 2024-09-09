using System;

namespace DataStructures.DataStructures
{
    public class BalancedTree
    {
        public BalancesTreeNode root;  // Pointer to root node
        public int t;           // Minimum degree

        // Constructor to initialize a B-tree
        public BalancedTree(int t)
        {
            this.t = t;
            root = null;
        }

        // Function to traverse the tree
        public void Traverse()
        {
            if (root != null)
            {
                root.Traverse();
            }
        }

        // Function to search a key in this tree
        public BalancesTreeNode Search(int k)
        {
            return root == null ? null : root.Search(k);
        }

        // Main function to insert a new key in this B-tree
        public void Insert(int k)
        {
            if (root == null)
            {
                // If the tree is empty, create a new root
                root = new BalancesTreeNode(t, true);
                root.keys[0] = k;
                root.n = 1;
            }
            else
            {
                if (root.n == 2 * t - 1)
                {
                    // If the root is full, create a new root and split the old root
                    BalancesTreeNode s = new BalancesTreeNode(t, false);
                    s.C[0] = root;
                    s.SplitChild(0, root);
                    int i = 0;

                    if (s.keys[0] < k)
                    {
                        i++;
                    }

                    s.C[i].InsertNonFull(k);
                    root = s;
                }
                else
                {
                    // If the root is not full, insert into the root
                    root.InsertNonFull(k);
                }
            }
        }
    }

    // A BTree node
    public class BalancesTreeNode
    {
        public int[] keys;        // An array of keys
        public BalancesTreeNode[] C;     // An array of child pointers
        public int n;             // Current number of keys
        public bool leaf;         // Indicates whether the node is a leaf
        public int t;             // Minimum degree (defines the range for the number of keys)

        // Constructor to initialize a B-tree node
        public BalancesTreeNode(int t, bool leaf)
        {
            this.t = t;
            this.leaf = leaf;
            this.keys = new int[2 * t - 1];
            this.C = new BalancesTreeNode[2 * t];
            this.n = 0;
        }

        // Function to insert a new key in a non-full node
        public void InsertNonFull(int k)
        {
            int i = n - 1;

            if (leaf)
            {
                // Insert key into a leaf node
                while (i >= 0 && keys[i] > k)
                {
                    keys[i + 1] = keys[i];
                    i--;
                }

                keys[i + 1] = k;
                n++;
            }
            else
            {
                // Insert key into a non-leaf node
                while (i >= 0 && keys[i] > k)
                {
                    i--;
                }

                if (C[i + 1].n == 2 * t - 1)
                {
                    // Split the child if it is full
                    SplitChild(i + 1, C[i + 1]);

                    if (keys[i + 1] < k)
                    {
                        i++;
                    }
                }

                C[i + 1].InsertNonFull(k);
            }
        }

        // Function to split a full child node
        public void SplitChild(int i, BalancesTreeNode y)
        {
            BalancesTreeNode z = new BalancesTreeNode(y.t, y.leaf);
            z.n = t - 1;

            // Copy the second half of keys from y to z
            for (int j = 0; j < t - 1; j++)
            {
                z.keys[j] = y.keys[j + t];
            }

            // Copy the second half of child pointers from y to z if y is not a leaf
            if (!y.leaf)
            {
                for (int j = 0; j < t; j++)
                {
                    z.C[j] = y.C[j + t];
                }
            }

            y.n = t - 1;

            // Rearrange keys and child pointers in the parent node
            for (int j = n; j > i; j--)
            {
                C[j + 1] = C[j];
            }

            C[i + 1] = z;

            for (int j = n - 1; j >= i; j--)
            {
                keys[j + 1] = keys[j];
            }

            keys[i] = y.keys[t - 1];
            n++;
        }

        // Function to traverse all nodes in a subtree rooted with this node
        public void Traverse()
        {
            int i;
            for (i = 0; i < n; i++)
            {
                if (!leaf)
                {
                    C[i].Traverse();
                }
                Console.Write(keys[i] + " ");
            }

            if (!leaf)
            {
                C[i].Traverse();
            }
        }

        // Function to search a key in the subtree rooted with this node
        public BalancesTreeNode Search(int k)
        {
            int i = 0;
            while (i < n && k > keys[i])
            {
                i++;
            }

            if (i < n && k == keys[i])
            {
                return this;
            }

            return leaf ? null : C[i].Search(k);
        }
    }
}