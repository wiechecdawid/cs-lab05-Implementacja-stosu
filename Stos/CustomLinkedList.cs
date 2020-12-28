using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stos
{
    //Simple linked list
    public class CustomLinkedList<T> : ICollection<T>, IEnumerable<T> 
    {

        private Node<T> _head;
        private int _current = -1;
        bool _isReadOnly = false;

        public Node<T> First { get => _head; }
        public Node<T> Last
        {
            get => _current > 0 ? this[_current] : _head;
        }

        int Count => _current + 1;

        int ICollection<T>.Count => Count;

        public bool IsReadOnly => _isReadOnly;


        protected Node<T> this[int i]
        {
            get
            {
                if (i > _current)
                    throw new IndexOutOfRangeException();
                Node<T> node = _head;

                for (int j = 1; j <= i; j++)
                    node = node.Next;

                return node;
            }
        }


        public void Add(T node)
        {
            if(!IsReadOnly && node != null)
            {
                Node<T> newNode = new Node<T>
                {
                    Head = node,
                    Next = null
                };

                if (_current == -1)
                {
                    _head = newNode;
                }
                else
                {
                    Node<T> tail = _head;

                    while (tail.Next != null)
                        tail = tail.Next;

                    tail.Next = newNode;
                }
                _current++;
            }
        }
        
        public void Clear()
        {
            _head = null;
        }

        public bool Contains(T item)
        {
            if(item == null && _head == null)
            {
                return true;
            }

            EqualityComparer<T> ct = EqualityComparer<T>.Default;

            var node = _head;
            do
            {
                if (ct.Equals(node.Head, item))
                    return true;
            }
            while ((node = node.Next) != null);

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("arrayIndex");
            }

            var node = _head;
            if(node != null)
            {
                do
                {
                    array[arrayIndex++] = node.Head;
                    node = node.Next;
                }
                while (node != null);
            }
        }

        public bool Remove(T item)
        {
            var c = EqualityComparer<T>.Default;
            var node = _head;

            if (c.Equals(item, node.Head))
            {
                _head = this[1];
                _current--;

                return true;
            }

            while(node.Next != null)
            {
                if(c.Equals(node.Next.Head, item))
                {
                    node.Next = node.Next.Next;
                    _current--;

                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;

            for (int i = 0; i <= _current; i++)
            {
                if (i > 0) node = node.Next;

                yield return node.Head;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Node<T>
    {
        public T Head { get; set; }
        public Node<T> Next { get; set; }
    }
}
