using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IOrnamentsPainter
    {
        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        OrnamentBounds GetSize(SKPoint size);

        void Draw(PaintContext context);

        /// <summary>
        /// Draw generic visible element. Usualy a boring square with frames
        /// </summary>
        /// <param name="paintContext"></param>
        void DrawVisible(PaintContext paintContext);
    }
}