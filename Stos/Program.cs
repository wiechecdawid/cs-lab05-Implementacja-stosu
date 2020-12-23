using System;

namespace Stos
{
    class Program
    {
        static void Main(string[] args)
        {
            StosWTablicy<string> s = new StosWTablicy<string>(2);
            s.Push("km");
            s.Push("aa");
            s.Push("xx");

            foreach (var x in s)
                Console.WriteLine(x);

            var rs = s.ReverseIterate();
            foreach (var r in rs)
                Console.WriteLine(r);

            Console.WriteLine();
        }
    }
}
