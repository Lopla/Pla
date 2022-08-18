using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles.LCars.ActiveElements
{
    public class TextActiveElement : IActiveElementPainter
    {
        private readonly IPalette _palette;
        private readonly BaseTextWidget _textWidget;

        public TextActiveElement(BaseTextWidget textWidget)
        {
            _palette = new LCarsPalette();
            _textWidget = textWidget;
        }

        private readonly SKTypeface _font = SKTypeface.Default;

        public float TextLineHeight { get; set; } = 16;

        public SKPoint GetSize()
        {
            var newSize = SKPoint.Empty;
            foreach (var t in _textWidget.TextLines())
            {
                var textSize = CalculateTextSize(t);
                newSize.Offset(0, textSize.Y);
                if (newSize.X < textSize.X) newSize.X = textSize.X;
            }

            return newSize;
        }

        private SKPaint GetTextPainter(SKTextAlign align = SKTextAlign.Center, SKColor? color = null)
        {
            return new SKPaint
            {
                TextSize = TextLineHeight,
                TextAlign = align,
                Typeface = _font,
                Color = color  ?? new SKColor(0,0,0)
            };
        }

        public SKPoint CalculateTextSize(string text)
        {
            SKRect bounds = default;
            var painter = GetTextPainter();
            painter.MeasureText(text, ref bounds);

            return new SKPoint(bounds.Width, painter.FontSpacing);
        }

        public void Draw(PaintContext paintContext)
        {
            float yOffset = 0;
            foreach (var t in _textWidget.TextLines())
            {
                var currentBounds = paintContext.Bounds;
                currentBounds.Offset(0, yOffset);
                var textSize = CalculateTextSize(t);
                currentBounds.Bottom = currentBounds.Top + textSize.Y;

                LineOfText(new PaintContext(currentBounds, paintContext.Canvas), t, SKTextAlign.Left, _palette.FrontColor(Ornament.Visible));

                yOffset += textSize.Y;
            }
        }

        private void LineOfText(PaintContext context, string text, SKTextAlign align, SKColor color)
        {
            var point = new SKPoint(context.Bounds.Left, context.Bounds.Top);

            switch (align)
            {
                case SKTextAlign.Center:
                    point.X = context.Bounds.MidX;
                    break;
                case SKTextAlign.Right:
                    point.X = context.Bounds.Right;
                    break;
                case SKTextAlign.Left:
                    point.X = context.Bounds.Left;
                    break;
            }

            using (var textPainter = GetTextPainter(align, color))
            {
                point.Offset(0, textPainter.TextSize);
                if (text != null)
                    context.Canvas.DrawText(text, point, textPainter);
            }
        }
    }
}