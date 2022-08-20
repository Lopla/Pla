using System;
using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IOrnamentsPainter
    {
        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        OrnamentBounds GetSizeAroundElement(IActiveElementPainter internalElement, OrnamentType ornament = OrnamentType.Visible);

        void Draw(PaintContext context, OrnamentType ornament = OrnamentType.Visible);
    }
}