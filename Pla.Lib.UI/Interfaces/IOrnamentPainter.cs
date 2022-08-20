using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IOrnamentPainter
    {
        void Draw(PaintContext context);
        OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize);
    }
}