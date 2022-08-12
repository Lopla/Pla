using SkiaSharp;

namespace Pla.Lib.UI
{
    public interface IDrawingStyle
    {
        void Pointable(PaintContext context);
        void Readable(PaintContext context);
        void Modifyable(PaintContext context);
    }

    public class PaintContext
    {
        public SKCanvas canvas;
        public SKRect widgetSize;
        public bool Focused;
    }
}