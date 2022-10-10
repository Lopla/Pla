using System.Collections.Generic;
using Pla.Lib.UI.DrawingStyles.LCars.Ornaments;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCarsStyle : IDesign
    {
        public LCarsStyle()
        {
            Ornaments = new OrnamentsDefinition(this);
            Palette = new LCarsPalette();
        }
        
        public IPalette Palette { get; }

        public IOrnamentsPainter Ornaments { get; }
        
        public IOrnamentPainter GetOrnamentPainter(OrnamentType type)
        {
            var d =  new Dictionary<OrnamentType, IOrnamentPainter>
            {
                { OrnamentType.WidgetContainer, new Frame(this) },
                { OrnamentType.Active, new EmptyFrame(this) },
                { OrnamentType.Modifiable, new EmptyFrame(this) },
                { OrnamentType.Visible, new EmptyFrame(this) }
            };

            return d[type];
        }
    }
}