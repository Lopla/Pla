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

            this.manager.AddWidget(new Button() { Label = "No Frame" });

            var f = this.manager.AddWidget(new Frame(new DrawingStyle()
            {
                Front = new SKPaint()
                {
                    Color = new SKColor(230, 200, 200)
                }
            }));
            f.AddWidget(new Button() { Label = "Frame1/1" });
            f.AddWidget(new Button() { Label = "Frame1/1" });

            var f2 = this.manager.AddWidget(new Frame(new DrawingStyle()
            {
                Front = new SKPaint()
                {
                    Color = new SKColor(200, 230, 200)
                }
            }));
            f2.AddWidget(new Button() { Label = "Frame2/1" });
            f2.AddWidget(new Button() { Label = "Frame2/2" });
            f2.AddWidget(new Button() { Label = "Frame2/3" });

            //this.engine.RequestTransparentWindow();
        }
    }
}
