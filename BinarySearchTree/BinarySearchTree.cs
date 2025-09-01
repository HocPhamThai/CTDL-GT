using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
            if (!Contains(root, elem)) return false;

            root = Remove(root, elem);
            nodeCount--;
            return true;
        }

        public IEnumerable<T> Traverse(TraverseOrder type)
        {
            return type switch
            {
                TraverseOrder.LevelOrder => LevelOrderTraversal(),
                TraverseOrder.PreOrder => new PreOrderTraversal<T>(root),
                TraverseOrder.InOrder => new InOrderTraversal<T>(root),
                TraverseOrder.PostOrder => new PostOrderTraversal<T>(root),
                _ => throw new ArgumentException()
            };
        }

        // LEVEL 1 -> NODE COUNT
        private IEnumerable<T> LevelOrderTraversal()
        {
            throw new NotImplementedException();
        }

        // ROOT - LEFT - RIGHT
        // PreOrderTraversal: (stack rỗng -> return) pop Current, dùng stack, đẩy Right trước rồi Left (LIFO)
        private class PreOrderTraversal<Titem> : IEnumerable<Titem>, IEnumerator<Titem>
        {
            private readonly Stack<Node<Titem>> _stack;
            private readonly Node<Titem>? _root;
            private bool _started;

            public PreOrderTraversal(Node<Titem>? root)
            {
                _root = root;
                _stack = new Stack<Node<Titem>>();
                if (root != null) _stack.Push(root);
            }

            public Titem Current { get; private set; } = default!;

            object IEnumerator.Current => Current!;

            public void Dispose() { }

            /// <summary>
            /// Lấy node tiếp theo trong PreOrder:
            /// - Nếu stack rỗng => không còn node nào để duyệt (return false)
            /// - Ngược lại: Pop node hiện tại, trả về Data
            /// - Push Right trước, rồi Left vào stack (vì stack là LIFO)
            /// </summary>
            public bool MoveNext()
            {
                if (_stack.Count == 0) return false;

                var current = _stack.Pop();
                Current = current.Data!;

                // Đẩy Right trước, Left sau (vì stack là LIFO)
                if (current.Right != null) { _stack.Push(current.Right); }
                if (current.Left != null) { _stack.Push(current.Left); }

                return true;
            }

            public void Reset()
            {
                _stack.Clear();
                if (_root != null) _stack.Push(_root);
                Current = default!;
            }

            public IEnumerator<Titem> GetEnumerator() => this;
            IEnumerator IEnumerable.GetEnumerator() => this;
        }

        // LEFT - ROOT -  RIGHT
        // InOrderTraversal: đi tới cùng bên trái (count node), pop, rồi sang phải
        private class InOrderTraversal<Titem> : IEnumerable<Titem>, IEnumerator<Titem>
        {
            private readonly Stack<Node<Titem>> _stack;
            private Node<Titem>? _current;
            private readonly Node<Titem>? _root; 

            public InOrderTraversal(Node<Titem>? root)
            {
                _root = root;
                _stack = new Stack<Node<Titem>>();
                Reset();
            }

            public Titem Current { get; private set; } = default!;

            object IEnumerator.Current => Current!;

            public void Dispose() { }

            /// <summary>
            /// Lấy node tiếp theo trong InOrder:
            /// - Đi hết nhánh trái, push node vào stack
            /// - Nếu stack rỗng => không còn node nào để duyệt (return false)
            /// - Pop node trên cùng => đó là Current
            /// - Chuyển sang nhánh phải của node vừa pop
            /// </summary>
            public bool MoveNext()
            {
                while (_current != null)
                {
                    _stack.Push(_current);
                    _current = _current.Left;
                };

                if (_stack.Count == 0) return false;

                _current = _stack.Pop();
                Current = _current.Data!;

                _current = _current.Right;

                return true;
            }

            public void Reset()
            {
                _stack.Clear();
                _current = _root;
                Current = default!;
            }

            public IEnumerator<Titem> GetEnumerator() => this;
            IEnumerator IEnumerable.GetEnumerator() => this;
        }

        // LEFT - RIGHT - ROOT
        private class PostOrderTraversal<Titem> : IEnumerable<Titem>, IEnumerator<Titem>
        {
            private readonly Stack<Node<Titem>> _stack;
            private Node<Titem>? _lastVisited;

            public PostOrderTraversal(Node<Titem>? root)
            {
                _stack = new Stack<Node<Titem>>();
                if (root != null) _stack.Push(root);
                _lastVisited = null;
            }

            public Titem Current { get; private set; } = default!;

            object IEnumerator.Current => Current!;

            public void Dispose() { }

            /// <summary>
            /// Lấy node tiếp theo trong PostOrder (Left → Right → Root):
            /// - Đi xuống cây theo nhánh trái càng sâu càng tốt
            /// - Nếu node hiện tại không có con hoặc con đã được duyệt → visit node (Current)
            /// - Nếu còn con chưa duyệt → tiếp tục đi sâu xuống
            /// - Nếu stack rỗng → đã duyệt hết (return false)
            /// </summary>
            public bool MoveNext()
            {
                while (_stack.Count > 0) {
                    var peek = _stack.Peek();

                    // Nếu node là lá hoặc đã duyệt hết con
                    if ((peek.Left == null && peek.Right == null) || 
                        ((_lastVisited != null) && (peek.Left == _lastVisited || peek.Right == _lastVisited)))
                    {
                        Current = peek.Data!;
                        _lastVisited = _stack.Pop();
                        return true;
                    }
                    else
                    {
                        if (peek.Right != null) _stack.Push(peek.Right);
                        if (peek.Left != null) _stack.Push(peek.Left);
                    }
                }

                return false;
            }   

            public void Reset()
            {
                _stack.Clear();
                _lastVisited = null;
            }

            public IEnumerator<Titem> GetEnumerator() => this;
            IEnumerator IEnumerable.GetEnumerator() => this;
        }


        //PRIVATE 
        private int Height(Node<T>? node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        // use recursion to get the result and then compare
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

        /// <summary>
        /// - Element in the leaf => set all to null
        /// - Element not in the left 
        /// - + left null => get right
        /// - + right null => get left
        /// - + if both are exists then 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="element"></param>
        /// <returns>root after remove</returns>
        private Node<T>? Remove(Node<T>? node, T element)
        {
            int result = element.CompareTo(node.Data);

            if (result > 0)
            {
                node.Right = Remove(node.Right, element);
            } 
            else if (result < 0)
            {
                node.Left = Remove(node.Left, element);
            } 
            else // Tìm thấy node cần xóa
            {
                // - + left null => get right
                // - + right null => get left
                if (node.Left == null) // Node chỉ có con phải hoặc không có node con
                {
                    Node<T>? rightNodte = node.Right;

                    node.Data = default;
                    node = null;

                    return rightNodte;
                } 
                else if (node.Right == null) // Node chỉ có con trái hoặc không có node con
                {
                    Node<T>? leftNode = node.Left;

                    node.Data = default;
                    node = null;

                    return leftNode;
                }
                else // Node có cả hai con - Lấy MaxLeft hoặc là MinRight để giữ nguyên tính chất của BST
                {
                    T? temp = MinRight(node.Right);

                    node.Data = temp;
                    node.Right = Remove(node.Right, temp);
                }
            }
            return node;
        }

        private T? MinRight(Node<T> rightNode)
        {
            while (rightNode.Left != null) rightNode = rightNode.Left;
            return (T?) rightNode.Data;
        }

        private T? MaxLeft(Node<T> leftNode)
        {
            while (leftNode.Right != null) leftNode = leftNode.Right;
            return (T?) leftNode.Data;
        }
    }
}
