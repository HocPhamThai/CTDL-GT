using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Node<K,V>
    {
        private int hash;
        private K key;
        private V value;


        public int Hash { get => this.hash; set => this.hash = value; }
        public K Key { get => this.key; }
        public V Value { get => this.value; set => this.value = value; }


        public Node(K key, V value)
        {
            this.hash = key?.GetHashCode() ?? 0;
            this.key = key;
            this.value = value;
        }

        public bool Equals(Node<K,V> other)
        {
            if (other is null || other.hash != this.hash) return false;
            return this.Key.Equals(other.key);
        }

        public override string ToString() => $"{Key}: {Value}";
    }
}
