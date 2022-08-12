using SkiaSharp;

namespace Pla.Lib.UI
{
    public class PaintContext
    {
        public SKCanvas Canvas;
        public Widget Widget;
        public bool Focused;

        public PaintContext(Widget widget, SKCanvas canvas, bool focused = false)
        {
            this.Canvas = canvas;
            this.Focused = focused;
            this.Widget = widget;
        }
    }
}