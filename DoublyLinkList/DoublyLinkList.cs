using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkList
{
    class DoublyLinkList<T> : ICollection<T>
    {
        private int count;
        private Node<T> sentinel;

        private static void CheckIfNodeIsNull(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Value cannot be null.");
            }
        }

        private void CheckIfListIsEmpty()
        {
            if (sentinel.Next == sentinel)
            {
                throw new InvalidOperationException("There are no elements to be removed!");
            }
        }

        public DoublyLinkList()
        {
            sentinel = new Node<T>();
            sentinel.Next = sentinel.Prev = sentinel;
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        public void AddLast(Node<T> newNode)
        {
            AddBefore(sentinel, newNode);
        }

        public void AddBefore(Node<T> node, T value)
        {
            AddBefore(node, new Node<T>(value));
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            CheckIfNodeIsNull(node);
            node.Prev.Next = newNode;
            newNode.Prev = node.Prev;
            newNode.Next = node;
            node.Prev = newNode;
            count++;
        }

        public void AddAfter(Node<T> node, T value)
        {
            AddAfter(node.Next, new Node<T>(value));
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            AddBefore(node.Next, newNode);
        }

        public void AddFirst(Node<T> newNode)
        {
            AddBefore(sentinel.Next, newNode);
        }

        public void AddFirst(T value)
        {
            AddBefore(sentinel.Next, new Node<T>(value));
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public bool Remove(T value)
        {
            Node<T> nodeToRemove = Find(value);
            if (nodeToRemove != null)
            {
                Remove(nodeToRemove);
                return true;
            }
            return false;
        }

        public void Remove(Node<T> nodeToRemove)
        {
            Node<T> previous = nodeToRemove.Prev;
            previous.Next = nodeToRemove.Next;
            nodeToRemove.Next.Prev = nodeToRemove.Prev;
            count--;
        }

        public void RemoveFirst()
        {
            CheckIfListIsEmpty();
            Remove(sentinel.Next);
        }

        public void RemoveLast()
        {
            CheckIfListIsEmpty();
            Remove(sentinel.Prev);
        }

        public Node<T> Find(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> current = sentinel;
            if (count > 0)
            {
                current = current.Next;
                while (current != sentinel)
                {
                    if (current.Data.Equals(node.Data))
                    {
                        return current;
                    }
                    current = current.Next;
                }
            }

            return null;
        }

        public Node<T> FindLast(T value)
        {
            Node<T> find = Find(value);
            if (find != null && find.Next == sentinel)
            {
                return find;
            }
            return null;
        }

        public void Clear()
        {
            sentinel.Next = sentinel.Prev = sentinel;
            count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Null array!");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            Node<T> node = sentinel.Next;
            do
            {
                array[arrayIndex++] = node.Data;
                node = node.Next;
            } while (node != sentinel);

        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = sentinel.Next; current != sentinel; current = current.Next)
            {
                yield return current.Data;
            }
        }

        public IEnumerator<Node<T>> GetNodeEnumerator()
        {
            for (var current = sentinel.Next; current != sentinel; current = current.Next)
            {
                yield return current;
            }
        }

        public int Count
        {
            get => count;
            set => count = value;

        }

        public bool IsReadOnly
        {
            get => false;
        }
    }
}
