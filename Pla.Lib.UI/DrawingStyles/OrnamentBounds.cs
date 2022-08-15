using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public class OrnamentBounds
    {
        public SKRect Bounds;

        public SKRect InternalBounds;

        public SKRect OffsetForInternalBounds(SKRect bounds)
        {
            var offsetBounds = bounds;
            offsetBounds.Offset(InternalBounds.Left, InternalBounds.Top);
            offsetBounds.Right = InternalBounds.Left + InternalBounds.Width;
            offsetBounds.Bottom = InternalBounds.Top + InternalBounds.Height;

            return offsetBounds;
        }
    }
}