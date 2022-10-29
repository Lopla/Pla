using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IElementPainter
    {
        SKPoint GetSize();
        
        void Draw(PaintContext paintContext);
    }
}