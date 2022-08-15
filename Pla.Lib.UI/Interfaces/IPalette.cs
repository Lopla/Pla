using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IPalette
    {
        SKColor Color(Styling styleInColor);
        SKColor Color(Ornament styleInColor);
    }
}