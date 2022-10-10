using System.Collections.Generic;
using Pla.Lib.UI.DrawingStyles.LCars;
using Pla.Lib.UI.DrawingStyles.LCars.Ornaments;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;
using Frame = Pla.Lib.UI.DrawingStyles.Ami.Ornaments.Frame;

namespace Pla.Lib.UI.DrawingStyles.Ami
{
    internal class AmiMagic : IDesign
    {
        public AmiMagic()
        {
            this.Ornaments = new OrnamentsDefinition(this);
            this.Palette = new AmiPalette();
        }
        
        public IOrnamentsPainter Ornaments { get; }
        public IPalette Palette { get; }

        public IOrnamentPainter GetOrnamentPainter(OrnamentType type)
        {
            var d = new Dictionary<OrnamentType, IOrnamentPainter>
            {
                { OrnamentType.WidgetContainer, new Frame(this) },
                { OrnamentType.Active, new EmptyFrame(this) },
                { OrnamentType.Modifiable, new EmptyFrame(this) },
                { OrnamentType.Visible, new EmptyFrame(this) }
            };

            return d[type];
        }
    }

    internal class AmiPalette : IPalette
    {
        public List<SKColor> _colors = new List<SKColor>()
        {
            new SKColor(149, 149, 149),
            new SKColor(000, 000, 000),
            new SKColor(255, 255, 255),
            new SKColor( 59, 103, 162),
            new SKColor(123, 123, 123),
            new SKColor(175, 175, 175),
            new SKColor(170, 144, 124),
            new SKColor(255, 169, 151),
        };
        public SKColor Color(Styling styleInColor)
        {
            return _colors[(int)styleInColor];
        }

        public SKColor FrontColor(OrnamentType styleInColor)
        {
            Dictionary<OrnamentType, Styling> colour = new Dictionary<OrnamentType, Styling>()
            {
                { OrnamentType.Visible, Styling.Background },
                { OrnamentType.Active, Styling.Background },
                { OrnamentType.Modifiable, Styling.Background },
                { OrnamentType.WidgetContainer, Styling.Border3 },
            };

            return Color(colour[styleInColor]);
        }

        public SKColor BackColor(OrnamentType styleInColor)
        {
            Dictionary<OrnamentType, Styling> colour = new Dictionary<OrnamentType, Styling>()
            {
                { OrnamentType.Visible, Styling.Border1 },
                { OrnamentType.Active, Styling.Border2 },
                { OrnamentType.Modifiable, Styling.Border3 },
                { OrnamentType.WidgetContainer, Styling.Background },
            };

            return Color(colour[styleInColor]);
        }
    }
}