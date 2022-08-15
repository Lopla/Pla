using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public interface IPalette
    {
        SKColor Color(Styling styleInColor);
    }
}