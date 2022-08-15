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

        public SKColor FrontColor(Ornament styleInColor)
        {
            Dictionary<Ornament, Styling> colour = new Dictionary<Ornament, Styling>()
            {
                { Ornament.Visible, Styling.Background },
                { Ornament.Active, Styling.Background },
                { Ornament.Modifiable, Styling.Border3 },
            };

            return Color(colour[styleInColor]);
        }

        public SKColor BackColor(Ornament styleInColor)
        {
            Dictionary<Ornament, Styling> colour = new Dictionary<Ornament, Styling>()
            {
                { Ornament.Visible, Styling.Border1 },
                { Ornament.Active, Styling.Border2 },
                { Ornament.Modifiable, Styling.Background },
            };

            return Color(colour[styleInColor]);
        }
    }
}