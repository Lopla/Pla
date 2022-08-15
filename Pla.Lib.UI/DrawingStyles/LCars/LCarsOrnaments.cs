using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars
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

        public void Draw(PaintContext context, 
            Ornament ornament)
        {
            using (var painterBack= new SKPaint
                   {
                       Color = _style.Palette.BackColor(ornament),
                       Style = SKPaintStyle.Fill
                   })
            using (var painterBorder = new SKPaint
                   {
                       Color = _style.Palette.FrontColor(ornament),
                       Style = SKPaintStyle.Stroke
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderWidth, BorderWidth, painterBack);
                context.Canvas.DrawRoundRect(context.Bounds, BorderWidth, BorderWidth, painterBorder);
            }
        }
        
        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public OrnamentBounds GetSize(SKPoint size, 
            Ornament ornament)
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