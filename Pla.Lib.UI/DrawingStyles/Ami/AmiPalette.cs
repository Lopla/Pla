using System.Collections.Generic;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.Ami
{
    internal class AmiPalette : IPalette
    {
        public List<SKColor> Colors = new List<SKColor>
        {
            new SKColor(175, 175, 175),

            new SKColor(149, 149, 149),
            new SKColor(000, 000, 000),
            new SKColor(255, 255, 255),
            new SKColor(59, 103, 162),

            new SKColor(123, 123, 123),
            new SKColor(175, 175, 175),
            new SKColor(170, 144, 124),
            new SKColor(255, 169, 151)
        };

        public SKColor Color(Styling styleInColor)
        {
            return Colors[(int) styleInColor];
        }

        public SKColor FrontColor(OrnamentType styleInColor)
        {
            var color = new Dictionary<OrnamentType, Styling>
            {

                {OrnamentType.Visible, Styling.Border1},
                {OrnamentType.Active, Styling.Border2},
                {OrnamentType.Modifiable, Styling.Border3},
                {OrnamentType.WidgetContainer, Styling.Background}
            };

            return Color(color[styleInColor]);
        }
    }
}