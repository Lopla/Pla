using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public class LCarsOrnaments : IOrnamentsPainter
    {
        public LCarsPalette Palette = new LCarsPalette();

        public void Draw(PaintContext context)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = Palette.Colour(Styling.Border7),
                       Style = SKPaintStyle.Stroke
                   })
            {
                context.Canvas.DrawRect(context.Bounds, painterBorder);
            }
        }


        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public OrnamentBounds GetSize(SKPoint size)
        {
            var result = new OrnamentBounds()
            {
                Bounds = 
                    SKRect.Inflate(new SKRect(0, 0, size.X, size.Y), 10, 10)
                        .Standardized,
                InternalOffset = new SKPoint(10, 10),
            };

            return result;
        }
    }

    public class OrnamentBounds
    {
        public SKRect Bounds;
        public SKPoint InternalOffset;
    }
}