using System.Collections.Generic;
using System.Linq;

namespace DataStructures.DataStructures
{
    public class BinarySearchTree
    {
        private TreeNode root;

        public BinarySearchTree()
        {
        }

        public void Insert(int value)
        {
            root = InsertRecursively(root, value);
        }

        // Delete a node from the BST
        public void Delete(int value)
        {
            root = DeleteRecursively(root, value);
        }

        // Search for a value in the BST
        public bool Search(int value)
        {
            return SearchRecursively(root, value);
        }

        // Inorder traversal of the BST
        public IEnumerable<int> InOrderTraversal() =>
            InOrderTraversalRecursively(root);

        private TreeNode InsertRecursively(TreeNode node, int value)
        {
            // If the tree is empty, return a new node
            if (node == null)
            {
                return new TreeNode(value);
            }

            // Otherwise, recur down the tree
            if (value < node.Value)
            {
                node.Left = InsertRecursively(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = InsertRecursively(node.Right, value);
            }

            // Return the unchanged node pointer
            return node;
        }

        private bool SearchRecursively(TreeNode node, int value)
        {
            // Base case: node is null or value is present at the node
            if (node == null)
            {
                return false;
            }

            if (node.Value == value)
            {
                return true;
            }

            // Value is greater than node's value
            if (value < node.Value)
            {
                return SearchRecursively(node.Left, value);
            }
            else
            {
                return SearchRecursively(node.Right, value);
            }
        }

        private List<int> InOrderTraversalRecursively(TreeNode node)
        {
            List<int> orderList = [];

            if (node != null)
            {
                orderList.AddRange(
                    InOrderTraversalRecursively(node.Left)
                        .Concat([node.Value])
                        .Concat(InOrderTraversalRecursively(node.Right))
                );
            }

            return orderList;
        }

        private TreeNode DeleteRecursively(TreeNode root, int value)
        {
            // Base case: if the tree is empty
            if (root == null)
            {
                return root;
            }

            // Otherwise, recur down the tree
            if (value < root.Value)
            {
                root.Left = DeleteRecursively(root.Left, value);
            }
            else if (value > root.Value)
            {
                root.Right = DeleteRecursively(root.Right, value);
            }
            else
            {
                // Node with only one child or no child
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                // Assign new value instead deleted node (smallest in the right subtree)
                root.Value = MinValue(root.Right);

                // Delete the inorder successor
                root.Right = DeleteRecursively(root.Right, root.Value);
            }

            return root;
        }

        private int MinValue(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Value;
        }
    }

    public class TreeNode(int value)
    {
        public int Value = value;
        public TreeNode Left = null;
        public TreeNode Right = null;
    }
}