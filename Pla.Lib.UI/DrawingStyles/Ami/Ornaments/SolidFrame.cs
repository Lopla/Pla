using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.Ami.Ornaments
{
    public class SolidFrame : IOrnamentPainter
    {
        private readonly IDesign _palette;
        private readonly bool _accentAround;
        private readonly FrameStyle _frameStyling;

        public enum FrameStyle
        {
            Sunken,
            Raised,
            None
        }

        public SolidFrame(IDesign style, bool accentAround=true, FrameStyle frameStyling = FrameStyle.None)
        {
            _palette = style;
            _accentAround = accentAround;
            _frameStyling = frameStyling;
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
                if(_accentAround)
                    context.Canvas.DrawRect(context.Bounds, painterBack);

                var b = context.Bounds;
                b.Inflate(-1, -1);
                if (_frameStyling == FrameStyle.Raised)
                {
                    context.Canvas.DrawLine(b.Right, b.Top, b.Right, b.Bottom, painterBack);
                    context.Canvas.DrawLine(b.Left, b.Bottom, b.Right, b.Bottom, painterBack);
                    context.Canvas.DrawLine(b.Left, b.Top, b.Right, b.Top, painterSecond);
                    context.Canvas.DrawLine(b.Left, b.Top, b.Left, b.Bottom, painterSecond);
                }else if (_frameStyling == FrameStyle.Sunken)
                {
                    context.Canvas.DrawLine(b.Right, b.Top, b.Right, b.Bottom, painterSecond);
                    context.Canvas.DrawLine(b.Left, b.Bottom, b.Right, b.Bottom, painterSecond);
                    context.Canvas.DrawLine(b.Left, b.Top, b.Right, b.Top, painterBack);
                    context.Canvas.DrawLine(b.Left, b.Top, b.Left, b.Bottom, painterBack);
                }
            }
        }

        public OrnamentBounds GetSizeAroundElement(SKPoint internalElementSize)
        {
            float frame = 2;
            float padding = 5;
            //// minimal frame size
            var ornamentSize = new SKRect(
                0, 0,
                internalElementSize.X + 2 * frame + 2 * padding,
                internalElementSize.Y + 2 * frame + 2 * padding);

            return new OrnamentBounds
            {
                Bounds = ornamentSize,
                InternalBounds = new SKRect(frame + padding, frame + padding, internalElementSize.X,
                    internalElementSize.Y)
            };
        }
    }
}