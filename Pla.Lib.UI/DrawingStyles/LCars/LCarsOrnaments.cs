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
            BorderWidth = 20;
        }

        public int BorderWidth { get; set; }

        public void Draw(PaintContext context,
            Ornament ornamentType)
        {
            using (var painterBack = new SKPaint
                   {
                       Color = _style.Palette.BackColor(ornamentType),
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderWidth, BorderWidth, painterBack);
            }
        }

        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        public OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize,
            Ornament ornamentType)
        {
            var yInflate =
                internalElementSize.Y > 2 * BorderWidth ? 0 : 3 * BorderWidth - internalElementSize.Y;

            var sizeWithOrnament = new SKRect(0, 0,
                internalElementSize.X + 2*BorderWidth,
                internalElementSize.Y + yInflate);

            var skInternalRect = new SKRect(BorderWidth, BorderWidth, internalElementSize.X, internalElementSize.Y);

            return new OrnamentBounds
            {
                Bounds = sizeWithOrnament,
                InternalBounds = skInternalRect
            };
        }
    }
}