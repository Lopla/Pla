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
            this.BorderWidth = 10;
        }

        public int BorderWidth { get; set; }

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

        public void DrawVisible(PaintContext paintContext)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _style.Palette.Color(Styling.Background),
                       Style = SKPaintStyle.StrokeAndFill
                   })
            {
                paintContext.Canvas.DrawRect(paintContext.Bounds, painterBorder);
            }
        }

        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public OrnamentBounds GetSize(SKPoint size)
        {
            var skRect = SKRect.Inflate(new SKRect(0, 0, size.X, size.Y), BorderWidth, BorderWidth).Standardized;

            var skInternalRect = new SKRect(BorderWidth, BorderWidth, size.X, size.Y);

            return new OrnamentBounds
            {
                Bounds = skRect,
                InternalBounds = skInternalRect
            };
        }
    }
}