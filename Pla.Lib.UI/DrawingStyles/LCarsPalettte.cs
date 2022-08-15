using System.Linq;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public class LCarsPalette
    {
        private readonly string[] _colorMap =
        {
            "#000000", // background and text
            "#ff7700", // orange - normal border
            "#ff2200", // red
            "#33cc99", // green
            "#666688", // gray
            "#ffcc33",
            "#cc88ff",
            "#ddbbff",
            "#cc4499",
            "#4455ff",
            "#ffcc33",
            "#9944ff",
            "#ffaa90",
            "#ffcc66",
            "#7788ff"
        };

        private readonly SKColor[] _colors;

        public LCarsPalette()
        {
            _colors = _colorMap.Select(SKColor.Parse).ToArray();
        }

        public SKColor Colour(Styling styleinColour)
        {
            return _colors[(int)styleinColour];
        }
    }
}