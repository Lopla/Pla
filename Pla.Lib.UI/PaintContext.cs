using Pla.Lib.UI.Widgets.Base;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public class PaintContext
    {

        public PaintContext(Widget widget, SKCanvas canvas, bool focused = false)
            : this(widget.Bounds, canvas, focused)
        {
        }

        public PaintContext(SKRect bounds, SKCanvas canvas, bool focused = false)
        {
            Canvas = canvas;
            Focused = focused;
            Bounds = bounds;
        }
        public SKCanvas Canvas;
        public bool Focused;
        public SKRect Bounds { get; set; }
    }
}