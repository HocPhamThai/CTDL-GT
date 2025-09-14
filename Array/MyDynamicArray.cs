using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class MyDynamicArray<T> : IEnumerable<T>
    {
        private T[] _arr;
        private int size = 0, capacity = 0;

        public MyDynamicArray() : this(10) { }

        public MyDynamicArray(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));

            this.capacity = capacity;
            _arr = new T[this.capacity];
        }

        public int Size()
        {
            return this.size;
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                _arr[i] = default;
            }
            this.size = 0;
        }

        public bool Contain(T item)
        {
            return IndexOf(item) != -1;
        }

        public T GetValue(int index)
        {
            return _arr[index];
        }

        public void SetValue(int index, T item)
        {
            _arr[index] = item;
        }

        public void Add(T item)
        {
            if (size >= capacity - 1)
            {
                if (capacity == 0)
                {
                    this.capacity = 1;
                }
                this.capacity *= 2;

                T[] newArr = new T[this.capacity];
                for (int i = 0; i < size; i++)
                {
                    newArr[i] = _arr[i];
                }
                _arr = newArr;
            }
            _arr[size++] = item;
        }

        public T RemoveAt(int removeIndex)
        {
            if (removeIndex < 0 || removeIndex >= size) throw new IndexOutOfRangeException(nameof(removeIndex));

            T item = _arr[removeIndex];
            T[] newArr = new T[size--];

            for (int oldIndex = 0, newIndex = 0; oldIndex < size; oldIndex++, newIndex++) 
            {
                if (oldIndex == removeIndex) newIndex--;
                else 
                    newArr[newIndex] = _arr[oldIndex];
            }

            _arr = newArr;
            capacity = --size;
            return item;
        }

        public void Remove(T item)
        {
            this.RemoveAt(IndexOf(item));
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (Equals(_arr[i], item))
                {
                    return i;
                }
            }
            return -1; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return _arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append('[');

            for(int i = 0; i < size; i++)
            {
                if (i == size - 1)
                {
                    sb.Append(_arr[i]);
                } 
                else
                {
                    sb.Append(_arr[i]); sb.Append(", ");
                }
            }

            sb.Append(']');
            return sb.ToString();
        }
    }
}
