using System;
using System.Collections.Generic;
using System.Text;
using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IOrnamentsPainter
    {
        void Draw(PaintContext context);

        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        OrnamentBounds GetSize(SKPoint size);
    }
}
