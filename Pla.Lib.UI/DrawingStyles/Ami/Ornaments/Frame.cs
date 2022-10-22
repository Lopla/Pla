using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.Ami.Ornaments
{
    public class Frame : IOrnamentPainter
    {
        private readonly IDesign _palette;

        public Frame(IDesign style)
        {
            _palette = style;
        }

        private float Border { get; } = 1;

        public void Draw(PaintContext context)
        {
            using (var painterBack = new SKPaint
                   {
                       Color = _palette.Palette.Color(OrnamentType.WidgetContainer),
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
                internalElementSize.X,
                internalElementSize.Y);

            return new OrnamentBounds
            {
                Bounds = ornamentSize,
                InternalBounds = new SKRect(Border, Border, internalElementSize.X, internalElementSize.Y)
            };
        }
    }
}