using Array;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplementation
{
    public class ArrayBasedStack<T> : StackADT<T>
    {
        private DynamicArray<T> _array;
        private int index = -1;

        public ArrayBasedStack() : this(10) { }

        public ArrayBasedStack(int capacity = 10)
        {
            _array = new DynamicArray<T>(capacity);
        }

        public bool IsEmpty()
        {
            return _array.IsEmpty();
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty!!!");
            }
            return _array.RemoveAtWithoutMoving(index--);
        }

        public T Top()
        {
            return _array.GetValue(index);
        }

        public void Push(T element)
        {
            index++;
            _array.Add(element);
        }

        public int Size()
        {
            return _array.Size();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
