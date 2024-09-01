using System;

namespace DataStructures.DataStructures
{
    public class IndexedPriorityQueue<T> where T : IComparable
    {
        private readonly int _maxN; // Maximum number of elements
        private int _n; // Number of elements in the priority queue
        private readonly int[] _pq; // Binary heap using 1-based indexing
        private readonly int[] _qp; // Inverse of _pq - _qp[_pq[i]] = _pq[_qp[i]] = i
        private readonly T[] _keys; // Keys with priorities

        public IndexedPriorityQueue(int maxN)
        {
            _maxN = maxN;
            _n = 0;
            _keys = new T[maxN + 1];
            _pq = new int[maxN + 1];
            _qp = new int[maxN + 1];
            for (int i = 0; i <= maxN; i++)
            {
                _qp[i] = -1;
            }
        }

        public bool IsEmpty() => _n == 0;
        public bool Contains(int index) => _qp[index] != -1;

        public void Insert(int index, T key)
        {
            if (Contains(index))
            {
                throw new ArgumentException("Index is already in the priority queue");
            }

            _n++;
            _qp[index] = _n;
            _pq[_n] = index;
            _keys[index] = key;
            Swim(_n);
        }

        public int MinIndex()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Priority queue underflow");
            }

            return _pq[1];
        }

        public T MinKey()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Priority queue underflow");
            }

            return _keys[_pq[1]];
        }

        public int DeleteMin()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Priority queue underflow");
            }

            int minIndex = _pq[1];
            Exchange(1, _n--);
            Sink(1);
            _qp[minIndex] = -1;  // Delete
            _keys[_pq[_n + 1]] = default(T); // Avoid loitering
            _pq[_n + 1] = -1; // Not needed

            return minIndex;
        }

        public void DecreaseKey(int index, T key)
        {
            if (!Contains(index))
            {
                throw new ArgumentException("Index is not in the priority queue");
            }

            if (_keys[index].CompareTo(key) <= 0)
            {
                throw new ArgumentException("Calling DecreaseKey() with given key would not decrease the key");
            }

            _keys[index] = key;
            Swim(_qp[index]);
        }

        public void IncreaseKey(int index, T key)
        {
            if (!Contains(index))
            {
                throw new ArgumentException("Index is not in the priority queue");
            }

            if (_keys[index].CompareTo(key) >= 0)
            {
                throw new ArgumentException("Calling IncreaseKey() with given key would not increase the key");
            }

            _keys[index] = key;
            Sink(_qp[index]);
        }

        private void Swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= _n)
            {
                int j = 2 * k;
                if (j < _n && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Exchange(k, j);
                k = j;
            }
        }

        private bool Greater(int i, int j)
        {
            return _keys[_pq[i]].CompareTo(_keys[_pq[j]]) > 0;
        }

        private void Exchange(int i, int j)
        {
            int swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;
            _qp[_pq[i]] = i;
            _qp[_pq[j]] = j;
        }
    }
}