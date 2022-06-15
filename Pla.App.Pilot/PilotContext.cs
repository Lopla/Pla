using Pla.Lib;
using Pla.Lib.UI;
using SkiaSharp;

namespace Pla.App.Pilot
{
    public class PilotContext : IContext
    {
        private IEngine engine;
        private Manager manager;

        public IControl GetControl()
        {
            return this.manager;
        }

        public IPainter GetPainter()
        {
            return this.manager;
        }

        public void Init(IEngine engine)
        {
            this.engine = engine;
            this.manager = new Manager(engine);

            var b = new Button()
            {
                Bounds = new SKRect(10, 100, 100, 130),
                Label = "Click me",
            };
            b.ClickedHandler += (loc) =>
            {
                System.Console.WriteLine("a");
                this.engine.RequestRefresh();
            };

            this.manager.Add(b);

            //this.engine.RequestTransparentWindow();
        }
    }
}
