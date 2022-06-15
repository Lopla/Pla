using System.Collections.Generic;
using Pla.Lib;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Manager : IControl, IPainter
    {
        public Manager(IEngine painter)
        {
            this.painter = painter;
        }

        List<Widget> Widgets = new List<Widget>();

        private readonly IEngine painter;

        public void Add(Widget widget)
        {
            Widgets.Add(widget);
            painter.RequestRefresh();
        }

        internal void Draw(SKCanvas canvas)
        {
            //var painter  = new SKColor(255,0,0,32);
            //canvas.Clear(painter);

            Widgets.ForEach(w => w.Draw(canvas));

            canvas.Flush();
        }

        public void Click(SKPoint argsLocation)
        {
            foreach (var w in Widgets)
            {
                if (w.Bounds.Contains(argsLocation))
                {
                    w.OnClick(argsLocation);
                }
            }
        }

        public void KeyDown(uint key)
        {

        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            this.Draw(surface.Canvas);
        }
    }
}