using LinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class SeperateChaningHashTable<K, V> : HashTableADT<K, V>
    {
        private const int DEFAULT_CAPACITY = 10;
        private const double DEFALUT_LOAD_FACTOR = 0.5;

        private double loadFactor;
        private int size = 0, capacity, threshold;

        private DoublyLinkedList<Node<K, V>>[]? table;

        public SeperateChaningHashTable() : this(DEFALUT_LOAD_FACTOR, DEFAULT_CAPACITY) { }

        public SeperateChaningHashTable(int capacity) : this(DEFALUT_LOAD_FACTOR, capacity) { }

        public SeperateChaningHashTable(double loadFactor, int capacity)
        {
            if (capacity < 0) throw new Exception("Capacity bi gi day Hoc oii");
            if (loadFactor <= 0) throw new Exception("LoadFactor bi gi day Hoc oii");
            this.loadFactor = loadFactor;
            this.capacity = Math.Max(capacity, DEFAULT_CAPACITY);
            this.threshold = (int)(this.capacity * loadFactor);
            this.table = new DoublyLinkedList<Node<K, V>>[this.capacity];
        }

        public int Size()
        {
            return this.size;
        }

        public bool IsEmpty()
        {
            return this.Size() == 0;
        }

        public void Clear()
        {
            Array.Fill(table, value: null);
            this.size = 0;
        }

        public int HashCodeToIndex(int hashedKey)
        {
            return (int)(hashedKey & 0xFFFFFFF) % capacity;
        }

        public bool Has(K key)
        {
            int index = HashCodeToIndex(key.GetHashCode());

            DoublyLinkedList<Node<K, V>> linkedList = table[index];
            if (linkedList == null || linkedList.IsEmpty()) return false;

            IEnumerator<Node<K, V>> enumerator = linkedList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Node<K, V> e = enumerator.Current;
                if (e.Key.Equals(key)) return true;
            }
            return false;
        }


        public V Insert(K key, V value)
        {
            int index = HashCodeToIndex(key.GetHashCode());
            DoublyLinkedList<Node<K, V>> linkedList = table[index];

            if (linkedList == null) linkedList = table[index] ??= new DoublyLinkedList<Node<K, V>>();

            Node<K, V>? existedNode = null;
            IEnumerator<Node<K, V>> enumerator = linkedList.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Node<K, V> node = enumerator.Current;
                if (node.Key.Equals(key))
                {
                    existedNode = node; break;
                }
            }

            if (existedNode == null)
            {
                linkedList.Add(new Node<K, V>(key, value));
                if (++size > threshold) ResizeTable();
                return default;
            }
            else
            {
                V oldValue = existedNode.Value;
                existedNode.Value = value;
                return oldValue;
            }
        }

        private void ResizeTable()
        {
            // Calculate new capacity and threshold
            this.capacity = capacity * 2;
            this.threshold = (int)(capacity * loadFactor);

            // Create a new table with the new capacity
            var newTable = new DoublyLinkedList<Node<K, V>>[this.capacity];

            // Rehash all existing entries into the new table
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    IEnumerator<Node<K,V>> enumerator = table[i].GetEnumerator();
                    
                    while (enumerator.MoveNext())
                    {
                        Node<K, V> node = enumerator.Current;

                        int index = HashCodeToIndex(node.Hash);

                        (newTable[index] ??= new DoublyLinkedList<Node<K, V>>()).Add(node);
                    }
                    table[i].Clear();
                    table[i] = null;
                }
            }
            this.table = newTable;
        }

        public V Get(K key)
        {
            int index = HashCodeToIndex(key.GetHashCode());
            DoublyLinkedList<Node<K, V>> linkedList = table[index];

            if (linkedList == null || linkedList.IsEmpty()) return default;

            IEnumerator<Node<K, V>> enumerator = linkedList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Node<K, V> node = enumerator.Current;
                if (node.Key.Equals(key)) return node.Value;
            }

            return default;
        }

        public V Remove(K key)
        {
            int index = HashCodeToIndex(key.GetHashCode());
            DoublyLinkedList<Node<K, V>> linkedList = table[index];

            if (linkedList == null || linkedList.IsEmpty()) return default;

            IEnumerator<Node<K, V>> enumerator = linkedList.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Node<K, V> node = enumerator.Current;
                --size;
                linkedList.Remove(node);
                return node.Value;
            }

            return default;
        }

        public IEnumerator<K> GetEnumerator()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    foreach (var node in table[i])
                    {
                        yield return node.Key;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
