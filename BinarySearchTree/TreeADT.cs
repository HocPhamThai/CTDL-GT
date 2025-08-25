using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public interface TreeADT<T> 
    {
        bool IsEmpty();
        int Size();
        int Height();
        bool Contains(T elem);
        bool Add(T elem);
        bool Remove(T elem);
        IEnumerable<T> Traverse(TraverseOrder type);
    }
}
