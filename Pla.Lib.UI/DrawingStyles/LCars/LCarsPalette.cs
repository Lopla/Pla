using System.Collections.Generic;
using System.Linq;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    public class LCarsPalette : IPalette
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

        public SKColor Color(Styling styleInColor)
        {
            return _colors[(int)styleInColor];
        }

        public SKColor FrontColor(OrnamentStyle styleInColor)
        {
            Dictionary<OrnamentStyle, Styling> colour = new Dictionary<OrnamentStyle, Styling>()
            {
                { OrnamentStyle.Visible, Styling.Background },
                { OrnamentStyle.Active, Styling.Background },
                { OrnamentStyle.Modifiable, Styling.Border3 },
                { OrnamentStyle.WidgetContainer, Styling.Border7 },
            };

            return Color(colour[styleInColor]);
        }

        public SKColor BackColor(OrnamentStyle styleInColor)
        {
            Dictionary<OrnamentStyle, Styling> colour = new Dictionary<OrnamentStyle, Styling>()
            {
                { OrnamentStyle.Visible, Styling.Border1 },
                { OrnamentStyle.Active, Styling.Border2 },
                { OrnamentStyle.Modifiable, Styling.Background },
                { OrnamentStyle.WidgetContainer, Styling.Background },
            };

            return Color(colour[styleInColor]);
        }
    }
}