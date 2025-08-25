using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class MyDynamicArray<T> : IEnumerable<T>
    {
        public T[] _array;
        public int size = 0;
        public int capacity = 0;
        
        public MyDynamicArray() : this(10){}

        public MyDynamicArray(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            
            this.capacity = capacity;

            this._array = new T[capacity];
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
            for(int i = 0; i < this.size; i++)
            {
                _array[i] = default;
            }
            this.size = 0;
        }

        public void Add(T element)
        {
           if(size >= this.capacity - 1) // Còn 1 chỗ trống thì tăng gấp đôi sức chứa của array
           {
                if (this.capacity == 0)
                {
                    this.capacity = 1;
                }
                this.capacity *= 2;

                T[] newArr = new T[capacity];
                for(int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = _array[i];
                }

                _array = newArr;
           }

           _array[size++] = element;
        }

        public T RemoveAt(int removeIndex)
        {
            if (removeIndex < 0 || removeIndex > capacity - 1) throw new ArgumentOutOfRangeException(nameof(removeIndex));
            
            T itemToRemove = _array[removeIndex];
            T[] newArr = new T[size - 1];

            for (int oldIndex = 0, newIndex = 0; oldIndex < size; oldIndex++, newIndex++)  
            {
                if (oldIndex == removeIndex) newIndex--;
                else
                {
                    newArr[newIndex] =  _array[oldIndex];  
                }
            }

            _array = newArr;
            capacity = --size;
            return itemToRemove;
        }

        public T RemoveAtNotMinusSize(int index) 
        {
            if (index < 0 || index >= size) throw new ArgumentOutOfRangeException(nameof(index));

            T itemToRemove = _array[index];
            
            for (int i = index + 1; i < size; i++)
            {
                _array[i - 1] = _array[i];
            }

            _array[--size] = default(T);
            return itemToRemove;
        }

        public T Remove(T obj)
        {
            int indexRemove = IndexOf(obj);
            return this.RemoveAt(indexRemove);
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < _array.Length; i++) 
            {
                if (element == null)
                {
                    if (_array[i] == null) return i;
                } 
                else
                {
                    if (element.Equals(_array[i])) return i;
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
            return new MyIntegerEnumarator<T>(_array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            if (IsEmpty()) return "[]";

            StringBuilder sb = new();
            
            sb.Append('[');
            for(int i = 0; i < this.size; i++)
            {
                if (i == size - 1)
                {
                    sb.Append(_array[i]);
                }
                else
                {
                    sb.Append(_array[i]); sb.Append(", ");
                }
            }
            sb.Append(']');

            return sb.ToString();
        }

        private class MyIntegerEnumarator<T> : IEnumerator<T>
        {
            private readonly T[] _arr;
            private int _currentIndex = -1;

            public MyIntegerEnumarator(T[] arr)
            {
                _arr = arr;
            }

            public T Current
            {
                get {
                    return _arr[_currentIndex];
                }
            }                       

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                // No resources to release
            }

            public bool MoveNext()
            {
                _currentIndex++;
                return _currentIndex < _arr.Length;
            }

            public void Reset()
            {
               _currentIndex = -1;
            }
        }
    }
}
