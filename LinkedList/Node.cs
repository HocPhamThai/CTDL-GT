using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Prev { get; set; } // Allow null values
        public Node<T>? Next { get; set; } // Allow null values

        public Node(T data, Node<T>? prev, Node<T>? next)
        {
            Data = data; // Ensure Data is not null
            Prev = prev;
            Next = next;
        }

        public override string ToString()
        {
            return Data?.ToString() ?? string.Empty; // Safely handle null Data
        }
    }
}
