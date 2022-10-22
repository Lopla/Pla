using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars.Ornaments
{
    public class EmptyFrame : IOrnamentPainter
    {
        private readonly IDesign _lCarsStyle;

        public EmptyFrame(IDesign lCarsStyle)
        {
            _lCarsStyle = lCarsStyle;
        }

        public void Draw(PaintContext context)
        {
            using (var painterBack = new SKPaint
                   {
                       Color = _lCarsStyle.Palette.Color(Styling.Border1),
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