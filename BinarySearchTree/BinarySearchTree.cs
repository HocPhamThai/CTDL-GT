using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> : TreeADT<T> where T : IComparable<T>
    {
        private int nodeCount = 0;

        private Node<T>? root = null;

        public bool IsEmpty()
        {
            return Size() == 0;
        }
        public int Size()
        {
            return nodeCount;
        }

        public int Height()
        {
            return this.Height(root);
        }

        public bool Contains(T elem)
        {
            return Contains(root, elem);
        }

        public bool Add(T elem)
        {
            if (Contains(root, elem)) return false;

            root = Add(root, elem);
            nodeCount++;
            return true;
        }

        public bool Remove(T elem)
        {
            return true;
        }

        public IEnumerable<T> Traverse(TraverseOrder type)
        {
            throw new NotImplementedException();
        }

        //PRIVATE 
        private int Height(Node<T>? node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private bool Contains(Node<T>? node, T element)
        {
            if (node == null) return false;

            int result = element.CompareTo((T?)node.Data);

            if (result < 0)
            {
                return Contains(node.Left, element);
            }
            else if (result > 0)
            {
                return Contains(node.Right, element);
            }
            else
            {
                return true;
            }
        }

        private Node<T>? Add(Node<T>? node, T element)
        {
            if (node == null) node = new Node<T>(element, null, null);
            else
            {
                if (element.CompareTo(node.Data) > 0)
                {
                    node.Right = Add(node.Right, element);
                } else
                {
                    node.Left = Add(node.Left, element);
                }
            }
            return node;
        }

        private Node<T>? Remove(Node<T>? node, T element)
        {
            //if (node == null) return ;
            return null;
        }
    }
}
