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

            var sa = s.ToArray();
            sa[0] = "bb";
            Console.WriteLine(sa[0]);

            var sroa = s.ToArrayReadOnly();
            // sroa[0] = "11"; - compilation error
        }
    }
}
