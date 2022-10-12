using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars.Ornaments
{
    public class Frame : IOrnamentPainter
    {
        private readonly IDesign _lCarsStyle;
        private float Border { get; set; } = 20;

        public Frame(IDesign lCarsStyle)
        {
            _lCarsStyle = lCarsStyle;
        }

        public void Draw(PaintContext context)
        {
            using (var painterBack = new SKPaint
                   {
                       Color = _lCarsStyle.Palette.Color(Styling.Border1),
                       Style = SKPaintStyle.Stroke
                   })
            {
                context.Canvas.DrawRect(context.Bounds, painterBack);
            }
        }

        public OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize)
        {
            //// minimal frame size
            var ornamentSize = new SKRect(0, 0,
                Border * 2 + internalElementSize.X,
                Border * 2 + internalElementSize.Y);

            return new OrnamentBounds
            {
                Bounds = ornamentSize,
                InternalBounds = new SKRect(Border, Border , internalElementSize.X, internalElementSize.Y)
            };
        }

    }
}
