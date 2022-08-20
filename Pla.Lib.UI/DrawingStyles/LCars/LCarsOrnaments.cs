using Pla.Lib.UI.DrawingStyles.LCars.Ornaments;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    public class LCarsOrnaments : IOrnamentsPainter
    {
        private readonly IDesign _style;

        public LCarsOrnaments(IDesign style)
        {
            _style = style;
        }

        public void Draw(PaintContext context,
            OrnamentType ornamentType)
        {

            new Frame().Draw(context, ornamentType);

        }


        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        public OrnamentBounds GetSizeAroundElement(IActiveElementPainter internalElement,
            OrnamentType ornamentType)
        {
            return
                new Frame().GetSizeAroundElement(internalElement.GetSize());
        }
    }
}