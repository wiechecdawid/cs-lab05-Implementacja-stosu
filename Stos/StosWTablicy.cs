using System;

namespace Stos
{
    public class StosWTablicy<T> : IStos<T>
    {
        private T[] tab;
        private int current = -1;

        public StosWTablicy(int size = 10)
        {
            tab = new T[size];
            current = -1;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : tab[current];

        public int Count => current + 1;

        public bool IsEmpty => current == -1;

        public void Clear() => current = -1;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            current--;
            return tab[current + 1];
        }

        public void Push(T value)
        {
            if (current == tab.Length - 1)
            {
                Array.Resize(ref tab, tab.Length * 2);
            }

            current++;
            tab[current] = value;
        }

        public T[] ToArray()
        {
            //return tab;  //bardzo źle - reguły hermetyzacji

            //poprawnie:
            T[] temp = new T[current + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = tab[i];
            return temp;
        }

        public void TrimExcess()
        {
            if(current > -1)
            {
                T[] temp = new T[current + (int)Math.Ceiling((decimal)current * 1 / 10)];

                for (int i = 0; i < temp.Length; i++)
                    temp[i] = tab[i];

                tab = temp;
            }
        }
    }
}
