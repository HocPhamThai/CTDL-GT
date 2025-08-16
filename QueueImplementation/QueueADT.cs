using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    public interface QueueADT<T> : IEnumerable<T>
    {
        T Enqueue(T item);
        T Dequeue();
        T Front();
        T Back();
        bool IsEmpty();
    }
}
