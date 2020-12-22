﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Stos
{
    public class StosWTablicy<T> : IStos<T>
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

        public T this[int index] { get => arr[index]; }

        public int TotalLength { get => arr.Length; }

        private class StackEnum<T> : IEnumerator<T>
        {
            T[] _objects;
            private int _index = -1;
            public StackEnum(T[] objects)
            {
                _objects = objects;
            }
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}