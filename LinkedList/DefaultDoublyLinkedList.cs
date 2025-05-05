using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DefaultDoublyLinkedList<T> : DoublyLinkedList<T>
    {
        private int size;
        private Node<T> head = null;
        private Node<T>? tail = null;
        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T item)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(item, null, null);
            }
            else
            {
                Node<T> newNode = new Node<T>(item, null, head);
                head.Prev = newNode;
                head = newNode;
            }
        }

        public void AddLast(T item)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(item, null, null);    
            } else
            {
                Node<T> newNode = new Node<T>(item, tail, null);
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void Clear()
        {
            Node<T> currentNode = head;
            while (currentNode != null) { 
                Node<T> nextNode = currentNode.Next;
                currentNode.Data = default(T);
                currentNode.Prev = null;
                currentNode.Next = null;
                currentNode = nextNode;
            }
            head = tail = null;
            size = 0;
        }

        public bool Contains(object obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object obj)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public T PeekFirst()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("LinkedList is empty!!!");
            }
            return head.Data;
        }

        public T PeekLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("LinkedList is empty!!!");
            }
            return tail.Data;
        }

        public T Remove(Node<T> node)
        {
            if (node.Prev == null)
            {
                RemovewFirst();
            }
            if (node.Next == null) 
            { 
                RemovewLast();
            }

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            size--;

            node.Prev = null;
            node.Next = null;
            node.Data = default(T);
            node = null;

            return node.Data;
        }

        public bool Remove(object obj)
        {
            Node<T> currNode = head;
            while (currNode.Next != null) 
            { 

                currNode = currNode.Next;
            }
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T RemovewFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("LinkedList is empty!!!");
            }
            T data = head.Data;
            head = head.Next;
            size--;
            if(IsEmpty())
            {
                tail = null;
            }else
            {
                head.Prev = null;
            }
            return data;
        }

        public T RemovewLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("LinkedList is empty!!!");
            }
            T data = tail.Data;
            tail = tail.Prev;
            size--;
            if (IsEmpty())
            {
                head = null;
            }
            else
            {
                tail.Next = null;
            }
            return data;
        }

        public int Size()
        {
            return size;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
