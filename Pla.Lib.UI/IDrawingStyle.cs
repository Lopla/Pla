using SkiaSharp;

namespace Pla.Lib.UI
{
    public interface IDrawingStyle
    {
        void PointAble(PaintContext context);
        void ReadAble(PaintContext context);
        void ModifyAble(PaintContext context);
        void Text(PaintContext context, string text, SKTextAlign align);
    }

    public class PaintContext
    {
        public SKCanvas canvas;
        public SKRect widgetSize;
        public bool Focused;
    }
}