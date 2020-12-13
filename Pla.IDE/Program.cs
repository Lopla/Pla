using System;
using Example;

namespace Pla.IDE
{
    class Program
    {
        static void Main(string[] args)
        {
            Pla.Linux.App.PlaMain(new Ctx());
            Console.WriteLine("Hello World!");
        }
    }
}
