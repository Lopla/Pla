using System.Collections.Generic;
using Pla.Lib;
using SkiaSharp;

namespace Example.GUI
{
    class Manager : IControl, IPainter
    {
        public Manager(IEngine painter)
        {
            this.painter = painter;
        }

        List<Widget> Widgets = new List<Widget>();

        private readonly IEngine painter;

        public void Add(Widget widget)
        {
            this.Widgets.Add(widget);
            this.painter.RequestRefresh();
        }

        internal void Draw(SKCanvas canvas)
        {         
            //var painter  = new SKColor(255,0,0,32);
            //canvas.Clear(painter);
                        
            this.Widgets.ForEach(w => w.Draw(canvas));

            canvas.Flush();
        }

        public void Click(SKPoint argsLocation)
        {
            foreach (var w in this.Widgets)
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