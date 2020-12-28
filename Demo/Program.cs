using Stos;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ints = new CustomLinkedList<int>();

            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            ints.Add(4);

            ints.Remove(3);

            foreach (var i in ints)
                Console.WriteLine(i);

            Console.WriteLine(ints.Contains(2));
            Console.WriteLine(ints.Contains(3));
        }
    }
}
