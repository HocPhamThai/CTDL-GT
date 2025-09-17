using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinkedList
{
    public class MyDoublyLinkedList<T> : DoublyLinkedListADT<T>
    {
        private int size = 0;
        private Node<T>? head = null;
        private Node<T>? tail = null;

        // O(n)
        public void Clear()
        {
            Node<T>? currentNode = head;

            while (currentNode != null)
            {
                Node<T>? nextNode = currentNode.Next;

                currentNode.Prev = null; currentNode.Data = default!; currentNode.Next = null;
    
                currentNode = nextNode;
            }
            head = tail = null;
            size = 0;
        }

        // constant
        public int Size()
        {
            return size;
        }

        // constant
        public bool IsEmpty()
        {
            return Size() == 0;
        }

        // O(1);
        public void Add(T item)
        {
            AddLast(item);
        }
        // O(1)
        public void AddFirst(T item)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(item, null, null);
            }
            else
            {
                Node<T> newNode = new Node<T>(item, null, head);
                head!.Prev = newNode;
                head = newNode;
            }
            size++;
        }
        // O(1)
        public void AddLast(T item)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(item, null, null);
            }
            else
            {
                Node<T> newNode = new Node<T>(item, tail, null);
                tail!.Next = newNode;
                tail = newNode;
            }
            size++;
        }

        // O(1)
        public T PeekFirst()
        {
            if (IsEmpty()) throw new Exception("LinkedList is Empty!!!");
            return head!.Data;
        }
        
        // O(1)
        public T PeekLast()
        {
            if (IsEmpty()) throw new Exception("LinkedList is Empty!!!");
            return tail!.Data;
        }

        // O(1)
        public T RemoveFirst()
        {
            if (IsEmpty()) throw new Exception("LinkedList is Empty!!!");

            Node<T>? oldHead = head!;
            T data = head!.Data;
            head = head.Next;
            size--;
            
            if (IsEmpty())
            {
                head = tail = null;
            }
            else
            {
                head!.Prev = null;
            }

            oldHead.Prev = null; oldHead.Data = default; oldHead.Next = null;
            size--;

            return data;
        }

        // O(1)
        public T RemoveLast()
        {
            if (IsEmpty()) throw new Exception("LinkedList is Empty!!!");

            Node<T> oldTail = tail!;
            T data = tail!.Data;
            tail = tail.Prev;
            size--;

            if (IsEmpty())
            {
                head = tail = null;
            }
            else
            {
                tail!.Next = null;
            }

            oldTail.Prev = null; oldTail.Data = default; oldTail.Next = null;
            size--;
            return data;
        }

        // O(n)
        public T Remove(Node<T> node)
        {
            T data = node!.Data;

            if (node.Prev == null) 
            {
                RemoveFirst();
            }
            else if (node.Next == null)
            {
                RemoveLast();
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
                size--;
            }

            node.Prev = null; node.Data = default; node.Next = null;
            return data;
        }

        public bool Remove(object obj)
        {
            Node<T>? currentNode = head;

            while (currentNode != null)
            {
                if (Equals(currentNode.Data, obj))
                {
                    Remove(currentNode);
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        // O(n)
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= size) throw new ArgumentOutOfRangeException("index");

            Node<T>? currNode;
            int i;

            if (index < size / 2)
            {
                currNode = head;
                i = 0;
                while (i != index)
                {
                    currNode = currNode!.Next;
                    i++;
                }
            } else
            {
                currNode = tail!;
                i = size - 1;
                while (i != index)
                {
                    currNode = currNode!.Prev;
                    i--;
                }
            }

            return Remove(currNode!);
        }

        // O(n)
        public int IndexOf(object obj)
        {
            Node<T>? currNode = head;
            int index = 0;

            while (currNode != null) 
            {
                if (Equals(currNode.Data, obj)) return index;
                currNode = currNode.Next; index++;
            }

            return -1;
        }

        // O(n)
        public bool Contains(object obj)
        {
            return IndexOf(obj) != -1;
        }

        public override string ToString()
        {
            if (IsEmpty()) return "[]";

            StringBuilder sb = new StringBuilder();
            
            sb.Append('[');
            Node<T>? currNode = head;
            while (currNode != null) 
            {
                sb.Append(currNode.Data);
                if (currNode.Next != null)
                {
                    sb.Append(", ");
                }
                currNode = currNode.Next;
            }
            sb.Append(']');

            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? node = head;

            while(node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
