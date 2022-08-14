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

        private readonly SKPaint _fontDrawingPainter;
        private readonly SKPaint _fontDrawingPainterWhite;
        public int Ascender;
        public int BorderMargin = 0;
        public int Descender;
        public int TextLineHeight;

        public LCars()
        {
            _colors = _colorMap.Select(SKColor.Parse).ToArray();
            var font = new SKFont(
                SKTypeface.Default
                //SKTypeface.FromFamilyName("Arial Narrow",
                //    SKFontStyleWeight.Bold,
                //    SKFontStyleWidth.ExtraCondensed,
                //    SKFontStyleSlant.Upright)
            );

            var TextSize = 18;

            _fontDrawingPainter = new SKPaint
            {
                Color = _colors[(int)Styling.Background],
                Typeface = font.Typeface,
                TextSize = TextSize
            };
            _fontDrawingPainterWhite = new SKPaint
            {
                Color = _colors[(int)Styling.Border1],
                Typeface = font.Typeface,
                TextSize = TextSize
            };

            Ascender = -(int)font.Metrics.Ascent;
            Descender = (int)font.Metrics.Descent;
            TextLineHeight = Ascender + Descender;
        }

        public SKPoint GetTextTotalSize(IEnumerable<string> TextLines)
        {
            var newSize = SKPoint.Empty;
            foreach (var t in TextLines)
            {
                var textSize = CalculateTextSize(t);
                newSize.Offset(0, textSize.Y);
                if (newSize.X < textSize.X) newSize.X = textSize.X;
            }

            newSize.Y += GetDescender();
            return newSize;
        }

        public SKPoint CalculateTextSize(string text)
        {
            SKRect bounds = default;
            _fontDrawingPainter.MeasureText(text, ref bounds);

            return new SKPoint(bounds.Width, GetTextHeight());
        }

        public int GetDescender()
        {
            return (int)_fontDrawingPainter.FontMetrics.Descent;
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

        public int GetTextHeight()
        {
            return (int)_fontDrawingPainter.TextSize;
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
                       Style = SKPaintStyle.StrokeAndFill
                   })
            using (var background = new SKPaint
                   {
                       Color = _colors[(int)Styling.Border6],
                       Style = SKPaintStyle.Fill
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
                Text(context, label, align, true);
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
                Text(context, label, align, false);
            }
        }

        public void ModifyAbleText(PaintContext ctx, string text, SKTextAlign align)
        {
            Text(ctx, text, align, false);
        }

        public void VisibleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            Text(paintContext, text, align, false);
        }

        public void PointAbleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            Text(paintContext, text, align, true);
        }

        private void Text(PaintContext context, string text, SKTextAlign align, bool dark)
        {
            var point = new SKPoint(context.Bounds.Left, context.Bounds.Top);

            if (align == SKTextAlign.Center)
                point.X = context.Bounds.MidX;
            else if (align == SKTextAlign.Right)
                point.X = context.Bounds.Right;
            else if (align == SKTextAlign.Left)
                point.X = context.Bounds.Left;


            var tempPainter = dark ? _fontDrawingPainter : _fontDrawingPainterWhite;

            point.Offset(0, tempPainter.TextSize);

            tempPainter.TextAlign = align;

            if (text != null)
                context.Canvas.DrawText(text, point, tempPainter);
        }
    }
}