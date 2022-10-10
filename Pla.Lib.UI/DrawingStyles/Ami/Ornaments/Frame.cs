using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.Ami.Ornaments
{
    public class Frame : IOrnamentPainter
    {
        private readonly IDesign _palette;
        private float Border { get; set; } = 1;

        public Frame(IDesign lCarsStyle)
        {
            _palette = lCarsStyle;
        }

        public void Draw(PaintContext context)
        {
            // top header
            using (var painterBack = new SKPaint
            {
                Color = _palette.Palette.FrontColor(OrnamentType.Active),
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 1,
            })
            {
                context.Canvas.DrawLine(
                    new SKPoint(
                        context.Bounds.Left,
                        context.Bounds.Top),
                    new SKPoint(
                        context.Bounds.Right,
                        context.Bounds.Top), painterBack);
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
                InternalBounds = new SKRect(Border, Border, internalElementSize.X, internalElementSize.Y)
            };
        }

    }
}
