using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplementation
{
    public interface StackADT<T> : IEnumerable<T>
    {
        void Push(T element);
        T Pop();
        T Top();
        int Size();
        bool IsEmpty();
    }
}
