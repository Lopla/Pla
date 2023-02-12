using Pla.App.Pilot;

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

            Pla.Win.App.PlaMain(new PilotContext());
        }
    }
}