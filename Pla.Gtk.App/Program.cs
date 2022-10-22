using System;

namespace Pla.Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            Pla.Gtk.App.PlaMain(new Pla.App.Pilot.PilotContext());
        }
    }
}
