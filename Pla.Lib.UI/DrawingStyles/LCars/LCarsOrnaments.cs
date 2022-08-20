using System.Collections.Generic;
using Pla.Lib.UI.DrawingStyles.LCars.ActiveElements;
using Pla.Lib.UI.DrawingStyles.LCars.Ornaments;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    public class LCarsOrnaments : IOrnamentsPainter
    {
        public Dictionary<OrnamentType, IOrnamentPainter> Ornaments = new Dictionary<OrnamentType, IOrnamentPainter>
        {
            { OrnamentType.WidgetContainer, new Frame() },
            { OrnamentType.Active, new TwoThinBorders() },
            { OrnamentType.Modifiable, new TwoThinBorders() },
            { OrnamentType.Visible, new TwoThinBorders() },
        };

        public void Draw(PaintContext context,
            OrnamentType ornamentType)
        {
            Ornaments[ornamentType].Draw(context);
        }


        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        public OrnamentBounds GetSizeAroundElement(IActiveElementPainter internalElement,
            OrnamentType ornamentType)
        {
            return Ornaments[ornamentType].GetSizeAroundElement(internalElement.GetSize());
        }
    }
}