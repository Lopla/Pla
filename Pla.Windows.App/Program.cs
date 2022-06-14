using Pla.App;
using Pla.App.Pilot;
using Pla.Win;

namespace Pla.Windows.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            //Application.Run(new PlaWindow());
            Pla.Win.App.PlaMain(new PilotContext());
        }
    }
}