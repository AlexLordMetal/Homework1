using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = false;
            bool b = false;
            Console.WriteLine("  a\t  b\ta&&b\ta||b\t !a\t !b");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine($"{a}\t{b}\t{a && b}\t{a || b}\t{!a}\t{!b}");
            b = true;
            Console.WriteLine($"{a}\t{b}\t{a && b}\t{a || b}\t{!a}\t{!b}");
            a = true;
            b = false;
            Console.WriteLine($"{a}\t{b}\t{a && b}\t{a || b}\t{!a}\t{!b}");
            b = true;
            Console.WriteLine($"{a}\t{b}\t{a && b}\t{a || b}\t{!a}\t{!b}");
            Console.ReadKey();
        }
    }
}
