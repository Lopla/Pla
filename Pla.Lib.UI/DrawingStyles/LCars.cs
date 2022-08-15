using System.Collections.Generic;
using System.Linq;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCars : IDesign
    {


        private readonly string[] _colorMap =
        {
            "#000000", // background and text
            "#ff7700", // orange - normal border
            "#ff2200", // red
            "#33cc99", // green
            "#666688", // gray
            "#ffcc33",
            "#cc88ff",
            "#ddbbff",
            "#cc4499",
            "#4455ff",
            "#ffcc33",
            "#9944ff",
            "#ffaa90",
            "#ffcc66",
            "#7788ff"
        };

        private readonly SKColor[] _colors;

        public int BorderMargin = 0;
        public int TextLineHeight = 16;
        private readonly SKTypeface _font = SKTypeface.Default;

        public LCars()
        {
            _colors = _colorMap.Select(SKColor.Parse).ToArray();
        }

        public SKPoint GetTextTotalSize(IEnumerable<string> textLines)
        {
            var newSize = SKPoint.Empty;
            foreach (var t in textLines)
            {
                var textSize = CalculateTextSize(t);
                newSize.Offset(0, textSize.Y);
                if (newSize.X < textSize.X) newSize.X = textSize.X;
            }
            
            return newSize;
        }

        public SKPoint CalculateTextSize(string text)
        {
            SKRect bounds = default;
            var painter = this.TextPainter();
            painter.MeasureText(text, ref bounds);

            return new SKPoint(bounds.Width, painter.FontSpacing);
        }
        
        public void DrawAllText(PaintContext paintContext, string[] textLines)
        {
            float yOffset = 0;
            foreach (var t in textLines)
            {
                var currentBounds = paintContext.Bounds;
                currentBounds.Offset(0, yOffset);
                var textSize = CalculateTextSize(t);
                currentBounds.Bottom = currentBounds.Top + textSize.Y;

                VisibleText(new PaintContext(currentBounds, paintContext.Canvas), t, SKTextAlign.Left);

                yOffset += textSize.Y;
            }
        }

        /// <summary>
        ///     Edit boxes
        /// </summary>
        /// <param name="context"></param>
        public void ModifyAble(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _colors[(int)Styling.Border7],
                       Style = SKPaintStyle.Stroke
                   })
            {
                context.Canvas.DrawRect(context.Bounds, painterBorder);

                ModifyAbleText(context, label, align);
            }
        }

        /// <summary>
        ///     Clickable touchable elements like buttons, radio etc.
        /// </summary>
        /// <param name="context"></param>
        public void PointAble(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _colors[(int)Styling.Border1],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBorder);
                LineOfText(context, label, align, true);
            }
        }

        /// <summary>
        ///     Passive ui element like frames and labels
        /// </summary>
        /// <param name="context"></param>
        public void Visible(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _colors[(int)Styling.Border1],
                       Style = SKPaintStyle.Stroke
                   })
            using (var painterBack = new SKPaint
                   {
                       Color = _colors[(int)Styling.Background],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBack);
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBorder);
                LineOfText(context, label, align, false);
            }
        }

        public void ModifyAbleText(PaintContext ctx, string text, SKTextAlign align)
        {
            LineOfText(ctx, text, align, false);
        }

        public void VisibleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            LineOfText(paintContext, text, align, false);
        }

        public void PointAbleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            LineOfText(paintContext, text, align, true);
        }

        private void LineOfText(PaintContext context, string text, SKTextAlign align, bool dark)
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

            var stylingColor = dark ? Styling.Background : Styling.Border1;

            SKColor color = _colors[(int)stylingColor];

            var textPainter = TextPainter(align, color);
            {
                point.Offset(0, textPainter.TextSize);
                if (text != null)
                    context.Canvas.DrawText(text, point, textPainter);
            }
        }

        private SKPaint TextPainter(SKTextAlign align = SKTextAlign.Center, SKColor? color=null)
        {
            return new SKPaint()
            {
                TextSize = this.TextLineHeight,
                TextAlign = align,
                Color = color ?? _colors[0],
                Typeface = _font
            };
        }
    }
}