using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public delegate void WidgetSelected(Widget selectedWidget);

    public class Manager : IControl, IPainter, IWidgetContainer
    {
        private readonly IEngine _painter;
        private readonly Frame _rootFrame = new Frame();

        public Manager(IEngine painter)
        {
            _painter = painter;
            _rootFrame.Parent = this;
        }

        public Widget Selected { get; set; }

        public void KeyDown(uint key)
        {
            Selected?.OnKeyDow(key);
        }

        public void Click(SKPoint argsLocation)
        {
            var w = _rootFrame.FindWidget(argsLocation);

            Selected?.LostFocus();
            Selected = w;
            OnWidgetSelected?.Invoke(w);
            w?.GotFocus();
            w?.OnClick(argsLocation);
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            surface.Canvas.Clear();

            var style = new LCars();
            _rootFrame.Draw(surface.Canvas, style);

            surface.Canvas.Flush();
        }

        public Widget Add(Widget widget)
        {
            _rootFrame.Add(widget);
            return widget;
        }

        public void Invalidate()
        {
            _painter.RequestRefresh();
        }

        public void RequestResize()
        {
        }

        public event WidgetSelected OnWidgetSelected;

        public IDesign GetStyle()
        {
            return new LCars();
        }
    }
}