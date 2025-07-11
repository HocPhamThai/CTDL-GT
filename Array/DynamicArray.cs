using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        public T[] _array;
        public int capacity = 0;
        public int size = 0;

        public DynamicArray() : this(10) { }

        public DynamicArray(int capacity)
        {
            // check data if capacity -1, -2, => throw exp
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity is non-negative!!!" + capacity);
            }
            // set capacity in length
            this.capacity = capacity;
            // create array type T with size = capacity
            _array = new T[capacity];
        }

        public int Size()
        {
            return this.size;
        }

        public bool IsEmpty()
        {
            return this.Size() == 0;
        }

        public T GetValue(int index)
        {
            return _array[index];
        }

        public void SetValue(int index, T element)
        {
            _array[index] = element;
        }

        public void Clear()
        {
            for (int i = 0; i < this.size; i++)
            {
                _array[i] = default(T);
            }
            this.size = 0;
        }

        public void Add(T element)
        {
            // capacity = 1 => size = 0;
            // capacity = 0 => size = 0;
            if (size >= capacity - 1)
            {
                if (capacity == 0)
                {
                    capacity = 1;
                }
                this.capacity *= 2;

                T[] newArr = new T[capacity];
                for (int i = 0; i < size; i++)
                {
                    newArr[i] = _array[i];
                }
                _array = newArr; 
                
            }
            _array[size++] = element;
        }

        public void RemoveAt(int removeIndex)
        {
            if (removeIndex >= capacity || removeIndex < 0) throw new IndexOutOfRangeException();

            T[] newArray = new T[size - 1];

            for (int oldIndex = 0, newIndex = 0; oldIndex < size; oldIndex++, newIndex++)
            {
                if (oldIndex == removeIndex) newIndex--;
                else
                {
                    newArray[newIndex] = _array[oldIndex];
                }
            }
            _array = newArray;
            capacity = --size;
        }

        public T RemoveAtWithoutMoving(int removeIndex)
        {
            if (removeIndex >= capacity || removeIndex < 0) throw new IndexOutOfRangeException();
            T item = _array[removeIndex];
            _array[removeIndex] = default(T);
            capacity = --size;
            return item;
        }

        public void Remove(T element)
        {
            int removeIndex = IndexOf(element);
            this.RemoveAt(removeIndex);
        }

        public int IndexOf(T? element)
        {
            for (int i = 0; i < size; i++)
            {
                if (element == null)
                {
                    if (_array[i] == null) return i;
                }
                else
                {
                    if(element.Equals(_array[i])) return i;
                }
            }
            return -1;
        }

        public bool Contain(T element)
        {
            return IndexOf(element) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < size; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            if (IsEmpty()) return "[]";
            StringBuilder sb = new StringBuilder();
            sb.Append("["); 
            for (int i = 0; i < size; i++)
            {
                if (i == size - 1)
                {
                    sb.Append(_array[i]);
                } 
                else
                {
                    sb.Append(_array[i]);
                    sb.Append(", ");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
