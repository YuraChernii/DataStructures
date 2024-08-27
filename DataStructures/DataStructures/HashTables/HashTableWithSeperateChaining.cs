using System;
using System.Collections.Generic;

namespace DataStructures.DataStructures.HashTables
{
    public class HashTableWithSeperateChaining<TKey, TValue>
    {
        private const int DefaultSize = 16;
        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

        public HashTableWithSeperateChaining(int size = DefaultSize)
        {
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            int bucketIndex = Math.Abs(hashCode % buckets.Length);

            return bucketIndex;
        }

        public void Add(TKey key, TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            foreach (KeyValuePair<TKey, TValue> kvp in buckets[bucketIndex])
            {
                if (kvp.Key.Equals(key))
                {
                    throw new ArgumentException("An element with the same key already exists.");
                }
            }

            buckets[bucketIndex].AddLast(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] != null)
            {
                foreach (KeyValuePair<TKey, TValue> kvp in buckets[bucketIndex])
                {
                    if (kvp.Key.Equals(key))
                    {
                        value = kvp.Value;

                        return true;
                    }
                }
            }

            value = default;

            return false;
        }

        public bool Remove(TKey key)
        {
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] != null)
            {
                var node = buckets[bucketIndex].First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        buckets[bucketIndex].Remove(node);

                        return true;
                    }
                    node = node.Next;
                }
            }

            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out var value))
                {
                    return value;
                }
                throw new KeyNotFoundException();
            }
            set
            {
                int bucketIndex = GetBucketIndex(key);
                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                }

                var node = buckets[bucketIndex].First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        node.Value = new KeyValuePair<TKey, TValue>(key, value);

                        return;
                    }

                    node = node.Next;
                }

                buckets[bucketIndex].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            }
        }
    }
}
