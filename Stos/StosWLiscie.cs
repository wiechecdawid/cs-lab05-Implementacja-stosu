using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stos
{
    class StosWLiscie<T> : IStos<T>, IEnumerable<T>
    {
        private CustomLinkedList<T> _list;

        public StosWLiscie()
        {
            _list = new CustomLinkedList<T>();
        }
        public T Peek => IsEmpty ? throw new StosEmptyException() : _list.Last.Head;

        public int Count => _list.Count;

        public bool IsEmpty => Count < 1;

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in _list)
                yield return element;
        }

        public T Pop()
        {
            var last = _list.Last.Head;
            _list.Remove(last);

            return last;
        }

        public void Push(T value)
        {
            _list.Add(value);
        }

        public T[] ToArray()
        {
            if(_list != null)
            {
                var arr = new T[_list.Count];

                _list.CopyTo(arr, 0);

                return arr;
            }

            throw new NullReferenceException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
