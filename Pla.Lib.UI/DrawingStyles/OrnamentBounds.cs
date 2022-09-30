using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public class OrnamentBounds
    {
        /// <summary>
        /// Request size bounds of complete element
        /// </summary>
        public SKRect Bounds;

        /// <summary>
        /// Internal active element bounds
        /// </summary>
        public SKRect InternalBounds;

        /// <summary>
        /// Align rect based on this element
        /// </summary>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public SKRect OffsetForInternalBounds(SKRect bounds)
        {
            var offsetBounds = bounds;
            offsetBounds.Offset(InternalBounds.Left, InternalBounds.Top);
            offsetBounds.Right = InternalBounds.Left + InternalBounds.Width;
            offsetBounds.Bottom = InternalBounds.Top + InternalBounds.Height;

            return offsetBounds;
        }

        public SKPoint RequestedSize()
        {
            return new SKPoint(Bounds.Width, Bounds.Height);
        }
    }
}