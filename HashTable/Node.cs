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
        public K Key { get => this.key; set => this.key = value; }
        public V Value { get => this.value; set => this.value = value; }


        public Node(int hash, K key, V value)
        {
            this.key = key;
            this.hash = key.GetHashCode();
            this.value = value;
        }

        public bool Equals(Node<K,V> other)
        {
            if (other.hash != this.hash) return false;
            return this.Key.Equals(other.key);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
