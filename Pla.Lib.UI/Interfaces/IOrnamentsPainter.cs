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
        OrnamentBounds GetSizeAroundElement(IActiveElementPainter internalElement, OrnamentStyle ornament = OrnamentStyle.Visible);

        void Draw(PaintContext context, OrnamentStyle ornament = OrnamentStyle.Visible);
    }
}