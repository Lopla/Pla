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
                Label = "Click me",
            };
            b.ClickedHandler += (loc) =>
            {
                System.Console.WriteLine("a");
                this.engine.RequestRefresh();
            };

            var f = this.manager.AddWidget(new Frame());
            f.AddWidget(new Button(){
                Label = "Legendary"
            });
            
            f.AddWidget(new Button(){
                Label = "Close"
            }); 

            f.Add(b);

            //this.engine.RequestTransparentWindow();
        }
    }
}
