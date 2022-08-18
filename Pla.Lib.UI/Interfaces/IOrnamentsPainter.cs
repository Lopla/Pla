using System;
using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IOrnamentsPainter
    {
        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        OrnamentBounds GetSizeAroundElement(IActiveElementPainter internalElement, Ornament ornament = Ornament.Visible);

        void Draw(PaintContext context, Ornament ornament = Ornament.Visible);
    }
}