using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public class LCarsOrnaments : IOrnamentsPainter
    {
        private readonly IDesign _style;

        public LCarsOrnaments(IDesign style)
        {
            _style = style;
        }

        public void Draw(PaintContext context)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _style.Palette.Color(Styling.Border7),
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
            var skRect = SKRect.Inflate(new SKRect(0, 0, size.X, size.Y), 10, 10).Standardized;

            var skInternalRect = new SKRect(10, 10, size.X, size.Y);

            return new OrnamentBounds
            {
                Bounds = skRect,
                InternalBounds = skInternalRect
            };
        }
    }
}