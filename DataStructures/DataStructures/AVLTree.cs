using System;
using System.Collections.Generic;

namespace DataStructures.DataStructures
{
    public class AVLTree<T> where T : IComparable
    {
        private AVLNode<T> _root;

        public void Insert(T value)
        {
            _root = Insert(_root, value);
        }

        public List<T> InOrderTraversal()
        {
            List<T> result = new();
            InOrderTraversal(_root, result);

            return result;
        }

        private AVLNode<T> Insert(AVLNode<T> node, T value)
        {
            if (node == null)
            {
                return new AVLNode<T>(value);
            }

            int compareResult = value.CompareTo(node.Value);
            if (compareResult < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (compareResult > 0)
            {
                node.Right = Insert(node.Right, value);
            }
            else
            {
                return node;
            }

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            return Balance(node);
        }

        private int GetHeight(AVLNode<T> node)
        {
            return node?.Height ?? 0;
        }

        private int GetBalanceFactor(AVLNode<T> node)
        {
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private AVLNode<T> Balance(AVLNode<T> node)
        {
            int balanceFactor = GetBalanceFactor(node);

            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(node.Left) < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }

            if (balanceFactor < -1)
            {
                if (GetBalanceFactor(node.Right) > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }

            return node;
        }

        private AVLNode<T> RotateLeft(AVLNode<T> node)
        {
            AVLNode<T> newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            newRoot.Height = 1 + Math.Max(GetHeight(newRoot.Left), GetHeight(newRoot.Right));

            return newRoot;
        }

        private AVLNode<T> RotateRight(AVLNode<T> node)
        {
            AVLNode<T> newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            newRoot.Height = 1 + Math.Max(GetHeight(newRoot.Left), GetHeight(newRoot.Right));

            return newRoot;
        }

        private void InOrderTraversal(AVLNode<T> node, List<T> result)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left, result);
            result.Add(node.Value);
            InOrderTraversal(node.Right, result);
        }
    }

    public class AVLNode<T> where T : IComparable
    {
        public T Value { get; set; }
        public AVLNode<T> Left { get; set; }
        public AVLNode<T> Right { get; set; }
        public int Height { get; set; }

        public AVLNode(T value)
        {
            Value = value;
            Height = 1;
        }
    }
}
