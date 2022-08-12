using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public delegate void WidgetSelected(Widget selctedWidget);

    public class Manager : IControl, IPainter, IWidgetContainer
    {
        public Manager(IEngine painter) : base()
        {
            this.painter = painter;
            this.rootFrame.Parent=this;
        }

        Frame rootFrame = new Frame();

        public Widget Add(Widget widget)
        {
            rootFrame.Add(widget);
            return widget;
        }

        private readonly IEngine painter;

        public void KeyDown(uint key)
        {
            if(this.Selected!=null)
            {
                this.Selected.OnKeyDow(key);
            }
        }

        public void Click(SKPoint argsLocation)
        {
            var w = rootFrame.FindWidget(argsLocation);

            this.Selected?.LostFocus();
            this.Selected = w;
            this.OnWidgetSelected?.Invoke(w);
            w?.GotFocus();
            w?.OnClick(argsLocation);
                      
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            var style = new LCars();
            rootFrame.Draw(surface.Canvas, style);

            surface.Canvas.Flush();
        }

        public void Invalidate()
        {
            this.painter.RequestRefresh();
        }

        public void RequestResize()
        {
            
        }

        public Widget Selected { get; set; }

        public event WidgetSelected OnWidgetSelected;
    }
}