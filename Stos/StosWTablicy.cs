using System;
using System.Collections;
using System.Collections.Generic;

namespace Stos
{
    public class StosWTablicy<T> : IStos<T>, IEnumerable<T>
    {
        private T[] arr;
        private int current = -1;

        public StosWTablicy(int size = 10)
        {
            arr = new T[size];
            current = -1;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : arr[current];

        public int Count => current + 1;

        public bool IsEmpty => current == -1;

        public void Clear() => current = -1;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            current--;
            return arr[current + 1];
        }

        public void Push(T value)
        {
            if (current == arr.Length - 1)
            {
                Array.Resize(ref arr, arr.Length * 2);
            }

            current++;
            arr[current] = value;
        }

        public T[] ToArray()
        {
            //return tab;  //bardzo źle - reguły hermetyzacji

            //poprawnie:
            T[] temp = new T[current + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = arr[i];
            return temp;
        }

        public void TrimExcess()
        {
            if(current > -1)
            {
                T[] temp = new T[current + 1 + (int)Math.Ceiling(((decimal)current + 1) * 1 / 10)];

                for (int i = 0; i < temp.Length; i++)
                    temp[i] = arr[i];

                arr = temp;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnum(arr);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index] { get => arr[index]; }

        public int TotalLength { get => arr.Length; }


        private class StackEnum : IEnumerator<T>
        {
            T[] _objects;
            private int _index = -1;
            public StackEnum(T[] objects)
            {
                _objects = objects;
            }
            public T Current 
            { 
                get
                {
                    try
                    {
                        return _objects[_index];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current { get => Current; }

            public void Dispose() { }

            public bool MoveNext() => ++_index < _objects.Length;

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
