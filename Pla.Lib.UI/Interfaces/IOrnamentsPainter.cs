using System;
using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public enum Ornament
    {
        Visible = 1,
        Modifiable = 2,
        Active = 3,
    }

    public interface IOrnamentsPainter
    {
        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        OrnamentBounds GetSizeAroundElement(SKPoint size, Ornament ornament = Ornament.Visible);

        void Draw(PaintContext context, Ornament ornament = Ornament.Visible);
    }
}