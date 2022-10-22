using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IPalette
    {
        SKColor Color(Styling styleInColor);
        SKColor FrontColor(OrnamentType styleInColor);
    }
}