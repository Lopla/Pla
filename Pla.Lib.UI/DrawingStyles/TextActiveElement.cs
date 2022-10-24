using System;
using System.Threading.Tasks;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Base;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public class TextActiveElement : IActiveElementPainter
    {
        private readonly SKColor _color;
        private readonly SKTypeface _font = SKTypeface.Default;
        private readonly IPalette _palette;
        private readonly TextWidget _textWidget;

        public TextActiveElement(OrnamentType style, TextWidget textWidget, IPalette palette)
        {
            _palette = palette;
            _textWidget = textWidget;
            _color = _palette.Color(style);
        }

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

        public void Draw(PaintContext paintContext)
        {
            float yOffset = 0;
            foreach (var t in _textWidget.TextLines())
            {
                var currentBounds = paintContext.Bounds;
                currentBounds.Offset(0, yOffset);
                var textSize = CalculateTextSize(t);
                currentBounds.Bottom = currentBounds.Top + textSize.Y;

                LineOfText(
                    new PaintContext(currentBounds, paintContext.Canvas),
                    t,
                    SKTextAlign.Left,
                    _palette.Color(OrnamentType.Visible));

                yOffset += textSize.Y;
            }
        }

        class TextCursor{
            private bool isActive =false;
            async Task Loop()
            {
                while (isActive)
                {
                    
                    //canvasView.InvalidateSurface();

                    await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
                }
            }

            public void Draw(PaintContext paintContext)
            {
                
            }
        }

        

        private SKPaint GetTextPainter(SKTextAlign align = SKTextAlign.Center)
        {
            return new SKPaint
            {
                TextSize = TextLineHeight,
                TextAlign = align,
                Typeface = _font,
                Color = _color
            };
        }

        public SKPoint CalculateTextSize(string text)
        {
            SKRect bounds = default;
            var painter = GetTextPainter();
            painter.MeasureText(text, ref bounds);

            return new SKPoint(bounds.Width, painter.FontSpacing);
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

            using (var textPainter = GetTextPainter(align))
            {
                point.Offset(0, textPainter.TextSize);
                if (text != null)
                    context.Canvas.DrawText(text, point, textPainter);
            }
        }
    }
}