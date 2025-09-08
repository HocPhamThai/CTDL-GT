using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public interface HashTableADT<K, V> : IEnumerable<K>
    {
        int Size();
        bool IsEmpty();
        void Clear();
        // hash code
        int HashCodeToIndex(int hashedKey);
        bool Has(K key);
        V Insert(K key, V value);
        V Get(K key);
        V Remove(K key);
    }
}
