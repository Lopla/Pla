using System;
using Gtk;

namespace Pla.Gtk.Tests
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            
            Application.Init ();

            Window window = new Window ("helloworld");
            window.Opacity = 0.05;
            window.DeleteEvent += delete_event;

            window.Show();

            Application.Run ();
        }
    }

    static void delete_event (object obj, DeleteEventArgs args)
    {
        Application.Quit ();
    }

}