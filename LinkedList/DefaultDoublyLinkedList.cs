using System.Collections;
using System.Text;

namespace LinkedList
{
    public class DefaultDoublyLinkedList<T> : DoublyLinkedList<T>
    {
        private int size;
        private Node<T>? head = null;
        private Node<T>? tail = null;
        public void Clear()
        {
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                Node<T> nextNode = currentNode.Next;
                currentNode.Data = default;
                currentNode.Prev = null;
                currentNode.Next = null;
                currentNode = nextNode;
            }
            head = tail = null;
            size = 0;
        }
        public int Size()
        {
            return size;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// Adds the specified item to the end of the collection.
        /// </summary>
        /// <param name="item">The item to add to the collection. Cannot be null.</param>
        public void Add(T item)
        {
            AddLast(item);
        }

        ///<summary>
        /// Adds an item to the beginning of the linked list.
        ///</summary>        
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
            size++;
        }

        /// <summary>
        /// Adds an item to the end of the linked list.
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            if (IsEmpty())
            {
                head = tail = new Node<T>(item, null, null);
            }
            else
            {
                Node<T> newNode = new Node<T>(item, tail, null);
                tail.Next = newNode;
                tail = newNode;
            }
            size++;
        }


        public bool Contains(object obj)
        {
            return IndexOf(obj) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currNode = head;
            while (currNode != null)
            {
                yield return currNode.Data;
                currNode = currNode.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(object obj)
        {
            int index = 0;
            Node<T> currNode = head;

            if (obj == null)
            {
                while (currNode != null)
                {
                    if (currNode.Data.Equals(obj))
                        return index;
                    currNode = currNode.Next;
                    index++;
                }
            }
            else
            {
                while (currNode != null)
                {
                    if (currNode.Data.Equals(obj))
                        return index;
                    currNode = currNode.Next;
                    index++;
                }
            }
            return -1;
        }


        public T PeekFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("LinkedList is empty!!!");
            }
            // head is guaranteed non-null here due to IsEmpty() check
            return head!.Data;
        }

        public T PeekLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("LinkedList is empty!!!");
            }
            return tail!.Data;
        }


        /// <summary>
        /// removes the specified node from the linked list.
        /// 1. If the node to be removed is the head, it calls `RemovewFirst`.
        /// 2. If the node to be removed is the tail, it calls `RemovewLast`.
        /// 3. Otherwise, it updates the `Prev` and `Next` pointers of the surrounding nodes to bypass the node being removed.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public T Remove(Node<T> node)
        {
            T data = node.Data;
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

            // Clear the node to help with garbage collection
            node.Prev = null;
            node.Next = null;
            node.Data = default;
            node = null;

            return data;
        }
        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("LinkedList is empty!!!");
            }
            T data = head.Data;
            head = head.Next;
            size--;
            if (IsEmpty())
            {
                tail = null;
            }
            else
            {
                head.Prev = null;
            }
            return data;
        }
        public T RemoveLast()
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

        // <summary>
        /// Removes the first occurrence of a specific object from the linked list.
        /// <param name="obj">The object to remove.</param>
        /// 1. Starting from the head, it traverses the linked list to find the first node that matches the specified object.
        /// 2. If the object is found, it calls the `Remove` method to remove that node.
        /// </summary>
        public bool Remove(object obj)
        {
            Node<T> currNode = head;

            if (obj == null)
            {
                while (currNode != null)
                {
                    if (currNode.Data == null)
                    {
                        Remove(currNode);
                        return true;
                    }
                    currNode = currNode.Next;
                }
            }
            else
            {
                while (currNode != null)
                {
                    if (obj.Equals(currNode.Data))
                    {
                        Remove(currNode);
                        return true;
                    }
                    currNode = currNode.Next;
                }
            }

            return false;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= size) throw new ArgumentException("Index is out of range of DoublyLinkedList");

            Node<T> currNode = head;
            int i;

            if (index < size / 2)
            {
                i = 0;
                currNode = head;
                while (i != index)
                {
                    currNode = currNode.Next;
                    i++;
                }
            }
            else
            {
                currNode = tail;
                i = size - 1;
                while (i != index)
                {
                    currNode = currNode.Prev;
                    i--;
                }
            }

            return Remove(currNode);
        }

        public override string ToString()
        {
            if (IsEmpty()) return "[]";
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            Node<T> currNode = head;
            while (currNode != null)
            {
                sb.Append(currNode.Data);
                if (currNode.Next != null)
                {
                    sb.Append(',');
                }
                currNode = currNode.Next;
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
