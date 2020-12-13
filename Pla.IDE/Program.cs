using System;

namespace Pla.IDE
{
    class Program
    {
        static void Main(string[] args)
        {
            Pla.Linux.PlaApp.App(new Example.Painter());
            Console.WriteLine("Hello World!");
        }
    }
}
