using System;
using System.Collections.Generic;

namespace DataStructures.DataStructures.HashTables
{
    public class HashTableWithLinearProbing<TKey, TValue>
    {
        private const int DefaultSize = 16;
        private TKey[] keys;
        private TValue[] values;
        private bool[] used;

        public HashTableWithLinearProbing(int size = DefaultSize)
        {
            keys = new TKey[size];
            values = new TValue[size];
            used = new bool[size];
        }

        public int Count { get; private set; }
        public int Capacity => keys.Length;

        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();

            return Math.Abs(hashCode % Capacity);
        }

        public void Add(TKey key, TValue value)
        {
            if (Count == Capacity)
            {
                throw new InvalidOperationException("Hash table is full.");
            }

            int index = GetBucketIndex(key);
            int originalIndex = index;

            while (used[index])
            {
                if (keys[index].Equals(key))
                {
                    throw new ArgumentException("An element with the same key already exists.");
                }

                index = (index + 1) % Capacity;

                if (index == originalIndex)
                {
                    throw new InvalidOperationException("No available slot found.");
                }
            }

            keys[index] = key;
            values[index] = value;
            used[index] = true;
            Count++;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = GetBucketIndex(key);
            int originalIndex = index;

            while (used[index])
            {
                if (keys[index].Equals(key))
                {
                    value = values[index];
                    return true;
                }

                index = (index + 1) % Capacity;

                if (index == originalIndex)
                {
                    break;
                }
            }

            value = default;
            return false;
        }

        public bool Remove(TKey key)
        {
            int index = GetBucketIndex(key);
            int originalIndex = index;

            while (used[index])
            {
                if (keys[index].Equals(key))
                {
                    used[index] = false;
                    keys[index] = default;
                    values[index] = default;
                    Count--;
                    Rehash();
                    return true;
                }

                index = (index + 1) % Capacity;

                if (index == originalIndex)
                {
                    break;
                }
            }

            return false;
        }

        private void Rehash()
        {
            var oldKeys = keys;
            var oldValues = values;
            var oldUsed = used;

            keys = new TKey[Capacity];
            values = new TValue[Capacity];
            used = new bool[Capacity];
            Count = 0;

            for (int i = 0; i < oldKeys.Length; i++)
            {
                if (oldUsed[i])
                {
                    Add(oldKeys[i], oldValues[i]);
                }
            }
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
                Add(key, value);
            }
        }
    }
}