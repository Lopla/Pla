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
        
        public void Draw(PaintContext context)
        {
            using (var painterBack = new SKPaint
                   {
                       Color = _palette.Palette.Color(1),
                       Style = SKPaintStyle.Stroke
                   })
            using (var painterSecond = new SKPaint
                   {
                       Color = _palette.Palette.Color(2),
                       Style = SKPaintStyle.Stroke
                   })
            {
                context.Canvas.DrawRect(context.Bounds, painterBack);

                var b = context.Bounds;
                b.Inflate(-1,-1);
                context.Canvas.DrawLine(b.Right, b.Top, b.Right, b.Bottom, painterBack);
                context.Canvas.DrawLine(b.Left, b.Bottom, b.Right, b.Bottom, painterBack);
                context.Canvas.DrawLine(b.Left, b.Top, b.Right, b.Top, painterSecond);
                context.Canvas.DrawLine(b.Left, b.Top, b.Left, b.Bottom, painterSecond);
            }
        }

        public OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize)
        {
            float frame = 2;
            float padding = 5;
            //// minimal frame size
            var ornamentSize = new SKRect(
                0, 0,
                internalElementSize.X + 2 * frame +2*padding,
                internalElementSize.Y + 2 * frame + 2*padding);

            return new OrnamentBounds
            {
                Bounds = ornamentSize,
                InternalBounds = new SKRect(frame+padding, frame+padding, internalElementSize.X, internalElementSize.Y)
            };
        }
    }
}