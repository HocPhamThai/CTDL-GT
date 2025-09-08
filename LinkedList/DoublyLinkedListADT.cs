using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public interface DoublyLinkedListADT<T> : IEnumerable<T>
    {
        // O(n)
        void Clear();
        // constant
        int Size();
        // constant
        bool IsEmpty();
        // O(1);
        void Add(T item);
        // O(1)
        void AddFirst(T item);
        // O(1)
        void AddLast(T item);
        // O(1)
        T PeekFirst();
        // O(1)
        T PeekLast();
        // O(1)
        T RemoveFirst();
        // O(1)
        T RemoveLast();
        // O(n)
        T Remove(Node<T> node);
        bool Remove(object obj);
        // O(n)
        T RemoveAt(int index);
        // O(n)
        int IndexOf(object obj);
        // O(n)
        bool Contains(object obj);

    }
}
