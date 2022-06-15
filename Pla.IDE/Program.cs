using System;
using Pla.App.Pilot;

namespace Pla.IDE
{
    class Program
    {
        static void Main(string[] args)
        {
            Pla.Gtk.App.PlaMain(new PilotContext());
        }
    }
}
