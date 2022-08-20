using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.Interfaces
{
    public interface IOrnamentsPainter
    {
        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        OrnamentBounds GetSizeAroundElement(IActiveElementPainter internalElement,
            OrnamentType ornament);

        void Draw(PaintContext context, OrnamentType ornament);
    }
}