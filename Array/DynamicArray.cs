using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        // this(10)
        public DynamicArray() : this(10) { }   


        // capacity < 0 throw exception
        // _array = new T[capacity]
        public DynamicArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity is non-negative!!!" + capacity);
            }
            this.capacity = capacity;

            _array = new T[capacity];
        }


        // return this.size
        public int Size()
        {
            return this.size;
        }


        // this.Size() == 0;
        public bool IsEmpty()
        {
            return this.Size() == 0;
        }


        // return _array[index]
        public T GetValue(int index)
        {
            return _array[index];
        }


        // _array[index] = element
        public void SetValue(int index, T element)
        {
            _array[index] = element;
        }


        // forech elements in _array -> set null
        public void Clear()
        {
            for (int i = 0; i < this.size; i++)
            {
                _array[i] = default;
            }
            this.size = 0;
        }


        // Add(T element) -> 
        // capacity < size -1 double size
        // capacity = 0 => capacity = 1;
        // create new array with double capacity
        // override old array by new array
        // arr[size++] = element;
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

        // loop parallel if = indexToRemove then newIndex-- (because new array has less than 1 element)
        // _array = newArray
        // capacity = --size;
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


        // that method serve for stack implementation
        public T RemoveAtWithoutMoving(int removeIndex)
        {
            if (removeIndex >= capacity || removeIndex < 0) throw new IndexOutOfRangeException();
            T item = _array[removeIndex];
            _array[removeIndex] = default;
            capacity = --size;
            return item;
        }

        // removeIndex = IndexOf (core method)
        public void Remove(T element)
        {
            int removeIndex = IndexOf(element);
            this.RemoveAt(removeIndex);
        }


        // foreach elemeent in _array if == null and == element return index; else return - 1;
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


        // index of element has value! -> return true;
        public bool Contain(T element)
        {
            return IndexOf(element) != -1;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
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

        // loop through every element of the _array and then use StringBuilder to concatenation element with ',' and the last element don't add ','
    }
}
