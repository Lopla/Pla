using System.Collections.Generic;
using Pla.Lib.UI.DrawingStyles.LCars.Ornaments;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    public class LCarsOrnaments : IOrnamentsPainter
    {
        public Dictionary<OrnamentType, IOrnamentPainter> Ornaments;

        public LCarsOrnaments(IDesign lCarsStyle)
        {
            this.Ornaments= new Dictionary<OrnamentType, IOrnamentPainter>
            {
                { OrnamentType.WidgetContainer, new Frame(lCarsStyle) },
                { OrnamentType.Active, new TwoThinBorders(lCarsStyle) },
                { OrnamentType.Modifiable, new TwoThinBorders(lCarsStyle) },
                { OrnamentType.Visible, new TwoThinBorders(lCarsStyle) }
            };
        }

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