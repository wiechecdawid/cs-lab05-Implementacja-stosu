using System;
using System.Collections.Generic;
using System.Text;

namespace Stos
{
    public class CustomLinkedList<T> : ICollection<T>, IEnumerable<T> 
    {
        private Node[] _nodes;
        private int _current = -1;

        public CustomLinkedList()
        {
            _nodes = new Node[10];
        }

        int Count => _current + 1;

        public void Add(T node)
        {
            if(_current == _nodes.Length - 1)
                Array.Resize(ref _nodes, _nodes.Length * 2)

            var n = new Node(node);

            _current++;
            _nodes[current] = n;

            if(current > 0)
                _nodes[current -1].Next = n;
        }

        public void Clear()
        {
            _nodes = new Node[10];
        }

        public bool Contains(T item)
        {
            if(item == null)
            {
                foreach(var n in _nodes)
                {
                    if(n == null)
                        return true;
                }
            }
            else
            {     
                var c = new EqualityComparer<T>.Default;           
                foreach(var n in _nodes)
                {
                    if(c.Equals(n.Head, item))
                        return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

        }

        public bool Remove(T item)
        {
            for(i = 0; i < _nodes.Length; i++)
            {

            }
        }

        public Collections.IEnumerable GetEnumerator() => GetEnumerator();

        public IEnumerable<T> GetEnumerator()
        {
            for(int i = 0; i < _current; i++)
                yield return (_nodes[i]);
        }

        private class Node
        {
            public Node(T node)
            {
                Head = node;
            }
            public T Head {get; set; }
            public T Next { get; set; } = null;
        }
    }
}
