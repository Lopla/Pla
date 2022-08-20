using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars.Ornaments
{
    public class Frame
    {
        private readonly IDesign _style = new LCarsStyle();

        public void Draw(PaintContext context, OrnamentStyle ornamentType)
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

        public OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize)
        {
            //// minimal frame size
            var ornamentSize = new SKRect(0, 0,
                BorderWidth * 2 + internalElementSize.X,
                BorderWidth * 2 + internalElementSize.Y);

            return new OrnamentBounds
            {
                Bounds = ornamentSize,
                InternalBounds = new SKRect(BorderWidth, BorderWidth, internalElementSize.X, internalElementSize.Y)
            };
        }

        public float BorderWidth { get; set; } = 10;
    }
}
