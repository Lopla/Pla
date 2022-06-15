using Pla.App;
using Pla.App.Pilot;
using Pla.Lib;
using Pla.Win;
using SkiaSharp;

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

    internal class ExperimentsContext : IContext, IPainter, IControl
    {
        private List<SKPoint> points = new List<SKPoint>();
        private IEngine e;

        public void Init(IEngine engine)
        {
            this.e = engine;
        }

        public IPainter GetPainter()
        {
            return this;
        }

        public IControl GetControl()
        {
            return this;
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            foreach (var p in points)
            {
                surface.Canvas.DrawPoint(p, SKColor.Parse("000"));
            }
            
        }

        public void Click(SKPoint argsLocation)
        {
            this.points.Add(argsLocation);
            this.e.RequestRefresh();
        }

        public void KeyDown(uint key)
        {
            
        }
    }
}