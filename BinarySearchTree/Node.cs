using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node<T> : IComparable<Node<T>>
    {
        public T? Data;
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

        public Node(T? data, Node<T>? left, Node<T>? right) { 
            this.Data = data;
            this.Left = left ?? null;
            this.Right = right ?? null;
        }

        public override string ToString()
        {
            return this.Data?.ToString() ?? string.Empty; 
        }

        public int CompareTo(Node<T>? other)
        {
            if (other == null)
            {
                return 1; // Current node is greater than null
            }

            // Assuming T implements IComparable<T>
            return Comparer<T>.Default.Compare(Data, other.Data);
        }
    }
}
